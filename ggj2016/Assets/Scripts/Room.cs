using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Room : MonoBehaviour
{

	public string roomName;
	bool _completed;

	public bool completed {
		get{ return _completed; } 
		set {
			_completed = value;
			if (value) {
				switch (roomName) {
				case "placard":
					Manager.Instance.LoadScene (3);
					break;
				case "chambre":
					Manager.Instance.LoadScene (5);
					break;
				case "livingRoom":
					Manager.Instance.LoadScene (4);
					break;
				default:
					break;
				}
			}
		}
	}

	public Bounds _bounds;
	public List<Item> itemsInRoom = new List<Item> ();

	Bounds bounds {
		get {
			if (_bounds.extents == Vector3.zero)
				_bounds = GetBounds ();

			return _bounds;
		}
	}

	private Bounds GetBounds ()
	{
		return new Bounds (roomBlack.bounds.center, roomBlack.bounds.size + (Vector3.forward * 200));
	}

	public SpriteRenderer roomBlack;


	public bool isInside (Vector2 pos)
	{
		return bounds.Contains (pos);
	}

	DoorAnimator[] doors;

	public void Awake ()
	{
		doors = GetComponentsInChildren<DoorAnimator> ();
		HouseManager.GetRooms ().Add (this);
	}

	void Start ()
	{
		foreach (var item in GetComponentsInChildren<Item>()) {
			itemsInRoom.Add (item);
		}
	}

	public bool FogVisible = false;

	public void Update ()
	{
		
		bool doorwasOpened = false;
		foreach (var door in doors) {
			doorwasOpened = door.doorOpened ? true : doorwasOpened;
		}

		if (roomBlack) {
			bool COntainsPlayer = bounds.Contains (HouseManager.instance.player.position);
			if (doorwasOpened || COntainsPlayer || completed) {
				
				DisappearFog ();
			} else if (!doorwasOpened) {
				AppearFog ();
			}
		}
	}

	private void DisappearFog ()
	{
		StartCoroutine (DisappearFogRoutine ());
	}

	private IEnumerator DisappearFogRoutine ()
	{
		roomBlack.material.renderQueue = 4000;
		roomBlack.material.SetFloat ("_DoorPosition", 0);
		roomBlack.material.SetFloat ("_Visibility", 0);
		yield return null;
	}

	private void AppearFog ()
	{
		StartCoroutine (AppearFogRoutine ());
	}

	private IEnumerator AppearFogRoutine ()
	{
		roomBlack.material.renderQueue = 4000;
		roomBlack.material.SetFloat ("_DoorPosition", 0);
		roomBlack.material.SetFloat ("_Visibility", 1);
		yield return null;
	}
}
