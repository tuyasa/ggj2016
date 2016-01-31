using UnityEngine;
using System.Collections;

public class ToiletSurprise : MonoBehaviour {

    SpriteRenderer sr;
    ParticleSystem pe;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        pe = GetComponent<ParticleSystem>();
    }

    [ContextMenu("FlipLid")]
    public void FlipLid()
    {
        sr.flipY = !sr.flipY;
        if (!sr.flipY) pe.Play();
        else pe.Stop();
    }
}
