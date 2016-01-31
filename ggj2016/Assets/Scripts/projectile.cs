using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
	public GameObject prefab_carres;
	GameObject carres;

	// Use this for initialization
	void Start () {
		carres = Instantiate(prefab_carres,transform.position, Quaternion.identity) as GameObject;
		Vector2 v = Random.insideUnitCircle;
		carres.GetComponent<Rigidbody2D>().AddForce (new Vector2(5*((v.x<0)?-(v.x):v.x),2*v.y));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
