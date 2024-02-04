using UnityEngine;

using Windows.Kinect;

using Vector4 = Windows.Kinect.Vector4;

public class DepthManager : MonoBehaviour
{
    private KinectSensor _sensor;
    private MultiSourceFrameReader _reader;
    private CoordinateMapper _mapper;
    public ushort[] _depthData;

    public FrameDescription DepthFrameDesc { get; private set; }
    public FrameDescription BodyIndexFrameDesc { get; private set; }
    public CameraSpacePoint[] CameraSpacePoints { get; private set; }
    public byte[] BodyIndexData { get; private set; }
    public Body[] BodyData { get; private set; }
    public Vector4 FloorClipPlane { get; private set; }
    // 座標修正用の行列
    public Matrix4x4 TransformMatrix
    {
        get
        {
            var q = Quaternion.FromToRotation(new(FloorClipPlane.X, FloorClipPlane.Y, FloorClipPlane.Z), Vector3.up);
            return Matrix4x4.TRS(new(0, FloorClipPlane.W, 0), q, Vector3.one);
        }
    }

    private void Awake()
    {
        _sensor = KinectSensor.GetDefault();

        if (_sensor == null) return;

        _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Depth | FrameSourceTypes.BodyIndex | FrameSourceTypes.Body);
        // 新しいフレームが取得された時に実行される関数の追加
        _reader.MultiSourceFrameArrived += OnMultiSourceFrameArrived;
        _mapper = _sensor.CoordinateMapper;

        DepthFrameDesc = _sensor.DepthFrameSource.FrameDescription;
        BodyIndexFrameDesc = _sensor.BodyIndexFrameSource.FrameDescription;

        // 配列の初期化
        _depthData = new ushort[DepthFrameDesc.LengthInPixels];
        CameraSpacePoints = new CameraSpacePoint[_depthData.Length];
        BodyIndexData = new byte[BodyIndexFrameDesc.LengthInPixels];
        BodyData = new Body[_sensor.BodyFrameSource.BodyCount];

        if (!_sensor.IsOpen)
        {
            _sensor.Open();
        }
    }

    private void OnApplicationQuit()
    {
        _reader?.Dispose();

        if (_sensor != null && _sensor.IsOpen)
        {
            _sensor.Close();
        }
    }

    private void OnMultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
    {
        var frame = e.FrameReference.AcquireFrame();

        if (frame == null) return;

        // usingは関数の最後に自動的にDispose()を呼び出す。depthFrame.Dispose()の必要なし。
        using var depthFrame = frame.DepthFrameReference.AcquireFrame();
        // 深度データの取得
        depthFrame.CopyFrameDataToArray(_depthData);
        // 三次元データへの変換
        _mapper.MapDepthFrameToCameraSpace(_depthData, CameraSpacePoints);
        using var bodyIndexFrame = frame.BodyIndexFrameReference.AcquireFrame();
        bodyIndexFrame.CopyFrameDataToArray(BodyIndexData);
        using var bodyFrame = frame.BodyFrameReference.AcquireFrame();
        FloorClipPlane = bodyFrame.FloorClipPlane;
        bodyFrame.GetAndRefreshBodyData(BodyData);

        for(int i=0;i<_depthData.Length;i++){
            if(_depthData[i] <=900){
                _depthData[i]=20000;
            }
        }
    }
}
