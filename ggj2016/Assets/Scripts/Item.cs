using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
<<<<<<< HEAD
=======

	public string name;
>>>>>>> fbdb4d2f215dc76a63a96b592e66af304c88b9fc
	ParticleSystem ps;

    public Vector3 originalPosition;
    public Room originalRoom;

	// Use this for initialization
	void Start () {
		ps = GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//lancer HighLight pour envoyer 10 particules
	void HighLight()
	{
		ps.Emit (10);
	}
}
