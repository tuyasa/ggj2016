using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class bkill : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player> () != null) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			other.GetComponent<Rigidbody2D> ().MovePosition (new Vector2 (-38.5f,48f));
		}
	}	
}