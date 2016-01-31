using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HouseManager : MonoBehaviour {


	public List<GameObject> gos;
    List<Item> items = new List<Item>(30);
    List<Room> rooms = new List<Room>(11);

	void Start () {

        foreach (GameObject go in gos)
        {
            Item i = go.GetComponent<Item>();
            if (i == null) i = go.AddComponent<Item>();

            items.Add(i);
        }

        

        //Shuffle and place
        for (int i = 0; i < items.Count; i++) {
            Item temp = items[i];
            int r = Random.Range(i, items.Count);
            items[i] = items[r];

            items[i].transform.position = temp.transform.position;
            items[i].transform.rotation = temp.transform.rotation;

            items[r] = temp;
        }

	}

}
