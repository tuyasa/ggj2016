using UnityEngine;
using System.Collections;


public class Item : MonoBehaviour {

	public string name;
	ParticleSystem ps;
	public Vector3 originalLocalScale;
	public Vector3 originalPosition;
	public Room originalRoom;

	// Use this for initialization
	void Start ()
	{
		ps = GetComponentInChildren<ParticleSystem> ();
		originalLocalScale = transform.localScale;
	}

	
	// Update is called once per frame
	void Update ()
	{
		
	}

	//lancer HighLight pour envoyer 10 particules
	void HighLight ()
	{
		ps.Emit (10);
	}
}
