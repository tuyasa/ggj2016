﻿using UnityEngine;
using System.Collections;

public class DoorAnimator : MonoBehaviour {

    public DoorAnimator twin;

    public Sprite[] sprites;
    SpriteRenderer sr;
    public void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    [ContextMenu("PlayAnim")]
    public void PlayAnim ()
    {
        StartCoroutine(PlayAnimRoutine());
    }

    [ContextMenu("PlayAnimInverse")]
    public void PlayAnimInverse()
    {
        StartCoroutine(PlayAnimRoutineInverse());
    }

    public IEnumerator PlayAnimRoutine()
    {
        int i = 0;
        while (i < sprites.Length)
        {
            sr.sprite = sprites[i++];
            yield return null;
        }
    }

    public IEnumerator PlayAnimRoutineInverse()
    {
        int i = sprites.Length-1;
        while (i >= 0)
        {
            sr.sprite = sprites[i--];
            yield return null;
        }
    }
//    void OnTriggerEnter2D(Collider2D other)
//    {
//    	Player player = other.GetComponent<Player>();
//    	if(player== null)
//    		return;
//    	PlayAnim();
//    	if(twin != null)
//    		twin.PlayAnim();
//    }
//	void OnTriggerExit2D(Collider2D other)
//    {
//    	Player player = other.GetComponent<Player>();
//    	if(player== null)
//    		return;
//    	PlayAnimInverse();
//    }
}