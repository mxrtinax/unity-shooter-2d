using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
	public Texture pointerTexture;
	Vector2 mousePosition;

	void Awake()
    {
		Cursor.visible = false;    
    }
    void Update()
	{
		mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		transform.position = mousePosition;
	}
	void OnGUI()
	{
		//Draw the pointer texture.
		if (pointerTexture != null)
			GUI.DrawTexture(new Rect(Input.mousePosition.x - (pointerTexture.width / 2), Screen.height - Input.mousePosition.y - (pointerTexture.height / 2), pointerTexture.width, pointerTexture.height), pointerTexture);
	}
}
