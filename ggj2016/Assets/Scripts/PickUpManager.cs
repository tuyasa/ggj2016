using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpManager : MonoBehaviour {

	public Transform holdPositon;
	public Item currentItem;
	public List<Item> pickUpItems;
	public List<Transform> rooms;

	public float maxDistanceToPickUp = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Item FindNearestObject()
	{
		foreach (var item in pickUpItems) {
			if(Vector2.Distance(transform.position,item.transform.position) < maxDistanceToPickUp)
				return item;
		}
		return null;
	}
	public void PickUpObjectNearestObject()
	{
		if(currentItem != null)
			return;
		Item pickItem = FindNearestObject();
		if(pickItem != null)
			currentItem = pickItem;
		currentItem.transform.SetParent(holdPositon);
	}
	public Transform FindRoom()
	{
		foreach (var room in rooms) {
			if(Vector2.Distance(transform.position,room.transform.position) < 3)
				return room;
		}
		return null;
	}
	public void DropOffCurrentObject()
	{
		Transform newParent = FindRoom();
		Debug.Log(newParent);
		if(newParent != null)
			currentItem.transform.SetParent(newParent);
		currentItem = null;

		// Find place where he stands



	}

}
