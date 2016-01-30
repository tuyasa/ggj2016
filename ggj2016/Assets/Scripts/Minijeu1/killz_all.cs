using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class killz_all : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player>()!=null )
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Debug.Log ("Success");
	}	
}