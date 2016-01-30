using UnityEngine;
using System.Collections;

public class AIController1 : MonoBehaviour {
	
	public GameObject prefab_bullet;
	GameObject bullet;
	public Vector2 []Pattern1;
	public Vector2 []Pattern2;
	public Vector2 []Pattern3;
	Vector2[] globalWaypoint;



	public float speed;
	private int wayPointIndex;
	float percentageBetweenPoints;
	// Use this for initialization
	void Start () {
		


		globalWaypoint = new Vector2[Pattern1.Length];
		for (int i = 0; i < Pattern1.Length; i++) {
			globalWaypoint[i] = Pattern1[i] + (Vector2)transform.position;
		}
		StartCoroutine ("bossPat");
	}

	// Update is called once per frame
	void Update () {
		Vector2	velocity = CalculateVelocity();
		transform.Translate(velocity);
		//	StartCoroutine(bossPat);
	}

	IEnumerator bossPat(){
		while (wayPointIndex != globalWaypoint.Length - 1) {
			yield return null;
		}//On attend la fin du pattern
		/*Entre 2 WP*/

		globalWaypoint = Pattern2;
		wayPointIndex = 0;

		while (wayPointIndex != globalWaypoint.Length - 1) {
			yield return null;
		}//On attend la fin du pattern

		globalWaypoint = Pattern3; 
		wayPointIndex = 0;	
}
	void boss_shoot()
	{
		bullet = Instantiate(prefab_bullet,transform.position+new Vector3(5,7,0), Quaternion.identity) as GameObject;

		bullet.GetComponentInChildren<Rigidbody2D>().AddForce (new Vector2(1500f,0f));
	}

	Vector3 CalculateVelocity()	{
		
		Vector2 newPos;
		//quand on a atteint le dernier wp, on retourne 0 : on ne bouge plus
		if(wayPointIndex!=0 && wayPointIndex % (globalWaypoint.Length-1) == 0)
			return new Vector2(0f,0f);
		
		wayPointIndex %= globalWaypoint.Length;
		int toWaypointIndex =  (wayPointIndex+1) % globalWaypoint.Length;
		float distanceBetweenWaypoints = Vector2.Distance(globalWaypoint[wayPointIndex],globalWaypoint[toWaypointIndex]);
		percentageBetweenPoints += Time.deltaTime * speed / distanceBetweenWaypoints;
		percentageBetweenPoints = Mathf.Clamp01(percentageBetweenPoints);
		newPos = Vector2.Lerp(globalWaypoint[wayPointIndex] , globalWaypoint[toWaypointIndex],percentageBetweenPoints);
//		Debug.Log(newPos);

		if(percentageBetweenPoints ==1)
		{
			percentageBetweenPoints = 0;
			wayPointIndex++;
			boss_shoot ();
		}

		return newPos -(Vector2) transform.position;
	}

	void OnDrawGizmos ()
	{
		if (Pattern1 != null) {
			Gizmos.color = Color.red;
			float size = 0.3f;
			for (int i = 0; i < Pattern1.Length; i++) {
				Vector2 globalWayPointPos = Application.isPlaying ? globalWaypoint [i] : (Vector2)transform.position + Pattern1 [i];
				Gizmos.DrawLine (globalWayPointPos + Vector2.down * size, globalWayPointPos + Vector2.up * size);
				Gizmos.DrawLine (globalWayPointPos + Vector2.left * size, globalWayPointPos + Vector2.right * size);

			}
		}
	}

}
