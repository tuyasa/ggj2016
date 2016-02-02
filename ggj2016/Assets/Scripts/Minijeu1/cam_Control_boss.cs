using UnityEngine;
using System.Collections;

public class cam_Control_boss : MonoBehaviour {

	public Transform target;
	public bool lockCamera;
	public GameObject boss;
	private bool bosscam = false;
	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!bosscam) {
			if (!lockCamera && !FindObjectOfType<LitlBot> ().get_cam ())
				transform.position = target.position + -10 * Vector3.forward;// + Vector3.up*5;
			else {
				bosscam = true;
				target = boss.GetComponent<Transform> ();
			}
		}
		else {
			transform.position = new Vector3 (target.position.x+16, 55, 0) + -15 * Vector3.forward;// + Vector3.up*5;
		}
		}
}
