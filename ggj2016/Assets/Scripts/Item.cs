using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public string name;
	ParticleSystem ps;

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
