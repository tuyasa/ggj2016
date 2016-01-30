using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	private SpriteRenderer[] spriteRenderes;

	// Use this for initialization
	void Start () {
		spriteRenderes = GetComponentsInChildren<SpriteRenderer>()	;
			
	}

	[ContextMenu("Fade")]
	void FadeIn(bool fade)
	{
		StartCoroutine(FadeInRoutine(side : fade ? -1 : 1));
	}


	IEnumerator FadeInRoutine (float side,float time = 0.8f)
	{
		float t = time;
		 
		while(t > 0)
		{
			t -= Time.deltaTime;
			SetAlphas(1-t/Time.time);
//			SetAlphas(t/Time.time);
			yield return null;
		}
	}
	void SetAlphas(float alpha)
	{
		foreach (var item in spriteRenderes) {
			item.color = Color.Lerp(Color.white,Color.clear,alpha);
		}
	}
}
