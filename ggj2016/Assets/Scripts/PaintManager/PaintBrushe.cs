using UnityEngine;
using System.Collections;

public enum ColorType
{
	Blue,
	Red,
	Green
}

public class PaintBrushe : MonoBehaviour
{
	
	Vector3 mainCamera;
	public ColorType color;
	public PaintManager ptM;
	private SpriteRenderer sprite;

	void Start ()
	{
		sprite = GetComponent<SpriteRenderer> ();
		switch (color) {
		case ColorType.Blue:
			sprite.color = Color.blue;
			break;
		case ColorType.Red:
			sprite.color = Color.red;
			break;
		case ColorType.Green:
			sprite.color = Color.green;
			break;
		default:
			sprite.color = Color.blue;
			break;
		}
	}

	void OnMouseDown ()
	{
		ptM.currentBrushe = this;
	}

	void OnMouseDrag ()
	{
		if(!enabled)
			 return;
		mainCamera = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mainCamera.z = 0f;
		transform.position = Vector2.Lerp (transform.position, mainCamera, Time.deltaTime * 10);
	}

	void OnMouseUp ()
	{
		ptM.currentBrushe = null;
	}
	// Use this for initialization

}
