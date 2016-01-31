using UnityEngine;
using System.Collections;

public class Painting : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		if(player==null)
			return;
		player.score++;
		Destroy(this.gameObject);
	}

}
