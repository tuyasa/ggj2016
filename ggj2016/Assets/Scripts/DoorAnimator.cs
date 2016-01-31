using UnityEngine;
using System.Collections;

public class DoorAnimator : MonoBehaviour {

    public DoorAnimator twin;

    public Sprite[] sprites;
    SpriteRenderer sr;
    private  BoxCollider2D boxCollider;
    public void Awake(){
    	gameObject.AddComponent<BoxCollider2D>();
    	boxCollider =GetComponent<BoxCollider2D>();
    }
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
        boxCollider.enabled = false;
    }

    public IEnumerator PlayAnimRoutineInverse()
    {
        int i = sprites.Length-1;
        while (i >= 0)
        {
            sr.sprite = sprites[i--];
            yield return null;
        }
		boxCollider.enabled = true;
    }
}
