using UnityEngine;
using System.Collections;

public class LitlBot : MonoBehaviour {
	public GameObject Destructosor;
	public GameObject Bloc_A_Activer;
	public GameObject img;
	public GameObject playa;

	GameObject camera;
	bool activate_cam2 = false;

	public bool get_cam() {
		return activate_cam2;
	}

	// Use this for initialization
	void Start () {
		//playa.transform.Translate (new Vector2 (15f,5f));
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void OnTriggerEnter2D(Collider2D o)
	{
		/*o.transform.right = -16;
		o.transform.up = 51.5;*/
		if ((o.GetComponent<Player> () )!= null) {
			
			o.GetComponent<Player> ().freezeMovement(4f);
			StartCoroutine("beMonstruous");

		}
			
	}


	IEnumerator beMonstruous()
	{	

		Bloc_A_Activer.SetActive (true);
		img.SetActive (true);
		transform.localScale += new Vector3 (2f, 2f,0);
		yield return new WaitForSeconds (0.5f);
		/*SI POSSIBLE FAIRE BOUGER LA CAMERA EN MODE WAWA UN BOSS*/

		playa.transform.position = new Vector3 (-16f, 51.4f, 0f);
		activate_cam2 = true;
		/*AFFICHER SI POSSIBLE UN TEXTE*/

		transform.localScale += new Vector3 (2f, 2f,0);
		yield return new WaitForSeconds (1f);
		img.SetActive (false);
		transform.localScale += new Vector3 (2f, 2f,0);
		yield return new WaitForSeconds (1f);
		transform.localScale += new Vector3 (4f, 4f,0);
		yield return new WaitForSeconds (1.5f);
		transform.localScale += new Vector3 (6f, 7f,0);
		yield return new WaitForSeconds (0.2f);
		img.SetActive (true);
		transform.localScale += new Vector3 (9f, 9f,0);
		yield return new WaitForSeconds (0.2f);
		img.SetActive (false);
		transform.localScale += new Vector3 (8f, 8f,0);
		yield return new WaitForSeconds (0.2f);
		img.SetActive (true);
		transform.localScale += new Vector3 (8f, 8f,0);
		yield return new WaitForSeconds (3f);
		img.SetActive (false);
		launch_boss ();
	}
	void launch_boss()
	{
		
		Destructosor.SetActive(true);
		Destroy (gameObject);
		//gameObject.SetActive(false);
	}
}
