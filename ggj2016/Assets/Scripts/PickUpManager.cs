using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpManager : MonoBehaviour
{

	public Transform holdPositon;
	public Item currentItem;
	public List<Item> pickUpItems;
	public List<Room> rooms;

	public float maxDistanceToPickUp = 1f;
	// Use this for initialization
	void Start ()
	{
		pickUpItems = HouseManager.GetItems ();
		rooms = HouseManager.GetRooms ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public Item FindNearestObject ()
	{
		foreach (var item in pickUpItems) {
			if (Vector2.Distance (transform.position, item.transform.position) < 2)
				return item;
		}
		return null;
	}

	public void PickUpObjectNearestObject ()
	{
		if (currentItem != null)
			return;
		Item pickItem = FindNearestObject ();
		if (pickItem != null)
			currentItem = pickItem;
		currentItem.transform.parent = holdPositon;
		currentItem.transform.localPosition = Vector3.zero;
	}

	public void DropOffCurrentObject ()
	{
		HouseManager.DropItem (currentItem, transform.position);
		currentItem = null;
	}

}
