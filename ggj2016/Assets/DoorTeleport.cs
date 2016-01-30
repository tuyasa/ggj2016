using UnityEngine;
using System.Collections;

public class DoorTeleport : MonoBehaviour {

	public DoorTeleport twin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D other)
	{
	 	Player player = other.GetComponent<Player>();
		 if(player != null && player.teleport)
	 	{
	 		Fade fade = other.GetComponent<Fade>();
	 		fade.FadeInFadeOut();
	 		player.transform.position = twin.transform.position;
	 		player.freezeMovement(0.9f);
	 	}
	}

}
