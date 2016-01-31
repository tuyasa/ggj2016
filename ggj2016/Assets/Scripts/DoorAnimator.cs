using UnityEngine;
using System.Collections;

public class DoorAnimator : MonoBehaviour {

    bool doorOpened = false;

    public DoorAnimator twin;

    public Sprite[] sprites;
    SpriteRenderer sr;
    private  BoxCollider2D boxCollider;

    public LayerMask mask;

    public void Awake(){
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }
    public void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ToggleDoor()
    {
        if(!doorOpened) StartCoroutine(PlayAnimRoutine());
        else StartCoroutine(PlayAnimRoutineInverse());
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
        boxCollider.gameObject.layer = 0;
        doorOpened = true;
    }

    public IEnumerator PlayAnimRoutineInverse()
    {
        int i = sprites.Length-1;
        while (i >= 0)
        {
            sr.sprite = sprites[i--];
            yield return null;
        }

        boxCollider.gameObject.layer = 8;
        
        doorOpened = false;
    }
}
