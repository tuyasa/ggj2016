﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class HouseManager : MonoBehaviour
{

	public static HouseManager instance;
	public Transform player;
	public List<GameObject> gos;
	List<Item> items = new List<Item> (30);
	List<Room> rooms = new List<Room> (11);

	public static List<Item> GetItems ()
	{
		return instance.items;
	}

	public static List<Room> GetRooms ()
	{
		return instance.rooms;
	}

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{

		foreach (GameObject go in gos) {
			Item i = go.GetComponent<Item> ();
			if (i == null)
				i = go.AddComponent<Item> ();

			items.Add (i);
		}

       
		//Shuffle and place
		for (int i = 0; i < items.Count; i++) {
			
			Item temp = items [i];
			temp.originalPosition = items [i].transform.position;
			temp.originalRoom = GetRoom (items [i].transform.position);

			int r = UnityEngine.Random.Range (0, items.Count);

			items [i] = items [r];
			items [i].originalPosition = items [r].transform.position;
			items [i].originalRoom = GetRoom (items [r].transform.position);

			items [i].transform.position = temp.transform.position;
			items [i].transform.rotation = temp.transform.rotation;

			items [r] = temp;
		}
		
	}

	public static Room GetRoom (Vector3 position)
	{
		foreach (Room room in instance.rooms)
			if (room.isInside (position))
				return room;

		return null;
	}

	public static void DropItem (Item currentItem, Vector3 atPosition)
	{
		if(currentItem.originalRoom.isInside(atPosition))
		{
			// Item well set
		}else {
			// not well placed
		}
		currentItem.transform.parent = null;
		currentItem.transform.position = atPosition;
		currentItem.originalLocalScale = new Vector3(1,1,1);
	}
}
