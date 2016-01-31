using UnityEngine;
using System.Collections;

public class SlamDoor : MonoBehaviour {

	public GameObject slamCollider;
	// Use this for initialization
	void Start () {
	
	}
	public void slam(){
		slamCollider.SetActive(true);
//		StartCoroutine("DisableCollider",0.4f);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
