using UnityEngine;
using System.Collections;

public class bloc2 : MonoBehaviour {
	Rigidbody2D rb;
	bool b = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(b)
			transform.Translate (new Vector2 (-4, 0)*Time.deltaTime);
	}

	IEnumerator mve(){
		yield return new WaitForSeconds (1.2f);
		b = true;

	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (b && other.GetComponent<Player> () == null) {			
			return;
		}

			StartCoroutine("mve");


	}

}
