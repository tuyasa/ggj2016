using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public bool lockCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!lockCamera)
			transform.position = target.position + -50 * Vector3.forward;// + Vector3.up*5;
	}
}
