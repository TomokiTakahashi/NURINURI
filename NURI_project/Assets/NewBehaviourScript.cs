using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixAccess : MonoBehaviour
 {
	Texture2D drawTexture ;
	Color[] buffer;

	void Start () {
		Texture2D mainTexture = (Texture2D) GetComponent<Renderer> ().material.mainTexture;
		Color[] pixels = mainTexture.GetPixels();

		buffer = new Color[pixels.Length];
		pixels.CopyTo (buffer, 0);

		drawTexture = new Texture2D (mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
		drawTexture.filterMode = FilterMode.Point;
	}

	public void Draw(Vector2 p)
	{
		buffer.SetValue (Color.black, (int)p.x + 256 * (int)p.y);
	}

	void Update () 
	{
		if (Input.GetMouseButton (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				Draw (hit.textureCoord * 256);
			}

			drawTexture.SetPixels (buffer);
			drawTexture.Apply ();
			GetComponent<Renderer> ().material.mainTexture = drawTexture;
		}
	}
}