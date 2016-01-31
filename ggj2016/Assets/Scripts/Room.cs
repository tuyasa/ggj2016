using UnityEngine;
using System.Collections;
using System;

public class Room : MonoBehaviour
{

	public string roomName;
	public Bounds _bounds;

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
			if (doorwasOpened || COntainsPlayer) {
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
