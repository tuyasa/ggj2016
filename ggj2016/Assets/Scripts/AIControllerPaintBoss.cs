﻿using UnityEngine;
using System.Collections;

public class AIControllerPaintBoss : MonoBehaviour {

	public Vector2 [] localWayPoints;
 	private Vector2[] globalWaypoints;
 
	public float speed;
	private int wayPointIndex;
	float percentageBetweenPoints;

	public GameObject itemsToThrow;

	public float maxWaitFireRate =0.8f;
	public float minWaitFireRate = 0.2f;
	private float nextFire = 0f;

	// Set in the manager number of painting to get 
	public int paintingToThrow;

	private int ammo;

	// Use this for initialization
	void Start () {
		ammo = paintingToThrow;
		globalWaypoints = new Vector2[localWayPoints.Length];
		for (int i = 0; i < localWayPoints.Length; i++) {
			globalWaypoints[i] = localWayPoints[i] + (Vector2)transform.position;
		}
	}

	// Update is called once per frame
	void Update () {

		if(Time.time > nextFire && ammo > 0)
		{
			StartCoroutine(ThrowStuff());
			nextFire = Time.time + Random.Range(minWaitFireRate,maxWaitFireRate);
		}
		Vector2	velocity = CalculateVelocity();
		transform.Translate(velocity);
	}

	Vector3 CalculateVelocity()	{
		
		Vector2 newPos;
		wayPointIndex %= globalWaypoints.Length;
		int toWaypointIndex =  (wayPointIndex+1) % globalWaypoints.Length;
		float distanceBetweenWaypoints = Vector2.Distance(globalWaypoints[wayPointIndex],globalWaypoints[toWaypointIndex]);
		percentageBetweenPoints += Time.deltaTime * speed / distanceBetweenWaypoints;
		percentageBetweenPoints = Mathf.Clamp01(percentageBetweenPoints);
		newPos = Vector2.Lerp(globalWaypoints[wayPointIndex] , globalWaypoints[toWaypointIndex],percentageBetweenPoints);

		if(percentageBetweenPoints ==1)
		{
			percentageBetweenPoints = 0;
//			wayPointIndex++;
			wayPointIndex = Random.Range(0,globalWaypoints.Length);
			nextFire += maxWaitFireRate;
		}


		return newPos -(Vector2) transform.position;
	}

	void OnDrawGizmos ()
	{
		if (localWayPoints != null) {
			Gizmos.color = Color.red;
			float size = 1f;
			for (int i = 0; i < localWayPoints.Length; i++) {
				Vector2 globalWayPointPos = Application.isPlaying ? globalWaypoints [i] : (Vector2)transform.position + localWayPoints [i];
				Gizmos.DrawLine (globalWayPointPos + Vector2.down * size, globalWayPointPos + Vector2.up * size);
				Gizmos.DrawLine (globalWayPointPos + Vector2.left * size, globalWayPointPos + Vector2.right * size);
			}
		}
	}

	IEnumerator ThrowStuff()
	{
		ammo--;
		GameObject go = Instantiate(itemsToThrow,transform.position,Quaternion.identity) as GameObject;
		Rigidbody2D rgbd = go.GetComponent<Rigidbody2D>();
		rgbd.AddForce(Vector2.down * 40,ForceMode2D.Impulse);
		yield return new WaitForSeconds(2f);
		Destroy(go.gameObject);
	}

}
