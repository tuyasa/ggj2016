using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintBucket : MonoBehaviour {

	public ColorType expectedColor;
	public SpriteRenderer inBucketColor;

	public void Start(){
		switch (expectedColor) {
		case ColorType.Blue:
		inBucketColor.color = Color.blue;
		break;
		case ColorType.Red:
		inBucketColor.color = Color.red;
		break;
		case ColorType.Green:
			inBucketColor.color = Color.green;
		break;
		default:
		inBucketColor.color = Color.blue;
			break;
		}
	}
}
