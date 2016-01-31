using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PaintManager : MonoBehaviour
{

	private List<PaintBrushe> brushes;
	private List<PaintBucket> buckets;
	public GameObject brushesGo;
	public GameObject bucketsGo;

	[HideInInspector]
	public PaintBrushe currentBrushe;
	private PaintBucket currentBucket;
	// Use this for initialization
	public float offset;

	void Awake ()
	{

		brushes = brushesGo.GetComponentsInChildren<PaintBrushe> ().ToList ();
		buckets = bucketsGo.GetComponentsInChildren<PaintBucket> ().ToList ();


		foreach (var item in buckets) {
			item.expectedColor = (ColorType)Random.Range (0, 3);
		}
		foreach (var item in brushes) {
			item.ptM = this;
			item.color = buckets [Random.Range (0, buckets.Count)].expectedColor;
		}
	}

	void Start ()
	{
		
	}

	void FindClosetBucket ()
	{

		if (currentBrushe == null)
			return;
		
		foreach (var item in  buckets) {
			if (Vector2.Distance (currentBrushe.transform.position, item.transform.position) < offset) {
				currentBucket = item;
			}
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if(brushes.Count == 0)
		{
			// Function It's over
			Debug.Log("END");
			return;
		}
			
		FindClosetBucket ();
		if (currentBucket == null || currentBrushe == null)
			return;
		
		if (currentBucket.expectedColor == currentBrushe.color) {
			brushes.Remove (currentBrushe);
			currentBrushe.enabled = false;
			currentBrushe = null;
			currentBucket = null;
		}
	}
}
