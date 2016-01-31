using UnityEngine;
using System.Collections;

public class DIsableToggleDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Player player = col.GetComponent<Player>();
		if(player==null)
			return;
		
		player.canOpenDoor = false;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		Player player = col.GetComponent<Player>();
		if(player==null)
			return;
		player.canOpenDoor = true;
	}
}
