using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		DoorAnimator door = other.GetComponent<DoorAnimator>();
		if(door == null)
			return;
		door.PlayAnim();
		door.twin.PlayAnim();
	}
}
