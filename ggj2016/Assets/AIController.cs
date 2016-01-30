using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	public Vector2 []localWayPoints;
 	public Vector2[] globalWaypoint;

	public float speed;
	private int wayPointIndex;
	float percentageBetweenPoints;
	// Use this for initialization
	void Start () {
		globalWaypoint = new Vector2[localWayPoints.Length];
		for (int i = 0; i < localWayPoints.Length; i++) {
			globalWaypoint[i] = localWayPoints[i] + (Vector2)transform.position;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector2	velocity = CalculateVelocity();
		transform.Translate(velocity);
	}

	Vector3 CalculateVelocity()	{
		
		Vector2 newPos;
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
		}


		return newPos -(Vector2) transform.position;
	}

	void OnDrawGizmos ()
	{
		if (localWayPoints != null) {
			Gizmos.color = Color.red;
			float size = 0.3f;
			for (int i = 0; i < localWayPoints.Length; i++) {
				Vector2 globalWayPointPos = Application.isPlaying ? globalWaypoint [i] : (Vector2)transform.position + localWayPoints [i];
				Gizmos.DrawLine (globalWayPointPos + Vector2.down * size, globalWayPointPos + Vector2.up * size);
				Gizmos.DrawLine (globalWayPointPos + Vector2.left * size, globalWayPointPos + Vector2.right * size);

			}
		}
	}

}
