﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
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
