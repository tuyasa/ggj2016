using UnityEngine;
using System.Collections;

public class LitlBot : MonoBehaviour {
	public GameObject Destructosor;
	public GameObject playa;
	GameObject camera;
	bool not_tooBig = true;
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
			
			o.GetComponent<Player> ().freezeMovement(3f);
			StartCoroutine("beMonstruous");

		}
			
	}

	IEnumerator beMonstruous()
	{	
		transform.localScale += new Vector3 (2f, 2f,0);
		yield return new WaitForSeconds (0.5f);
		/*SI POSSIBLE FAIRE BOUGER LA CAMERA EN MODE WAWA UN BOSS*/

		playa.transform.position = new Vector3 (-16f, 51.4f, 0f);
		activate_cam2 = true;

		/*AFFICHER SI POSSIBLE UN TEXTE*/
		transform.localScale += new Vector3 (2f, 2f,0);
		yield return new WaitForSeconds (1f);
		transform.localScale += new Vector3 (2f, 2f,0);
		yield return new WaitForSeconds (1f);
		transform.localScale += new Vector3 (4f, 4f,0);
		yield return new WaitForSeconds (2f);
		transform.localScale += new Vector3 (6f, 7f,0);
		yield return new WaitForSeconds (0.2f);
		transform.localScale += new Vector3 (9f, 9f,0);
		yield return new WaitForSeconds (0.2f);
		transform.localScale += new Vector3 (20f, 20f,0);
		yield return new WaitForSeconds (0.2f);
		transform.localScale += new Vector3 (20f, 20f,0);

		yield return new WaitForSeconds (0.4f);
		launch_boss ();
	}
	void launch_boss()
	{
		
		Destructosor.SetActive(true);
		gameObject.SetActive(false);
	}
}
