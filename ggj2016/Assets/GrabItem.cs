using UnityEngine;
using System.Collections;
using System.Linq;

public class GrabItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Item item = other.GetComponent<Item>();
		if(item == null)
			return;
		Player player = GetComponentInParent<Player>();
		item.transform.position = player.itemHolder.transform.position;
		item.transform.SetParent(player.itemHolder.transform);
		foreach (var spr in item.GetComponentsInChildren<SpriteRenderer>()) {
			spr.sortingOrder = player.GetComponentInChildren<SpriteRenderer>().sortingOrder+1;
		}
	}
}
