using UnityEngine;
using System.Collections;

public class game_completed : MonoBehaviour {
	bool completed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	bool room_isCompleted(){
		return completed;
	}

	void OnTriggerEnter2D(Collider2D o){
		if (o.GetComponent<Player> ()!= null) {
			completed = true;
			Debug.Log ("MINIJEU TERMINE");
		}
	}
}
