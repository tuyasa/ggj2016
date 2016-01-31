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
        gameObject.SetActive(false);

        Debug.Log(other.gameObject.name);
        Debug.Log(other.isTrigger);
        Debug.Log(other.enabled);

        DoorAnimator door = other.GetComponent<DoorAnimator>();
		if(door == null) return;
		door.ToggleDoor();
		door.twin.ToggleDoor();
	}
}
