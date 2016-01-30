using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{

	private SpriteRenderer[] spriteRenderes;

	// Use this for initialization
	void Start ()
	{
		spriteRenderes = GetComponentsInChildren<SpriteRenderer> ();
			
	}
	public void FadeInFadeOut()
	{	
		StartCoroutine(FadeTo());
	}

//	public void Fadein ()
//	{
//		FadeTo (true);
//	}
//
//
//	public void FadeOut ()
//	{
//		FadeTo (false);
//	}

//	void FadeTo (bool side)
//	{
//		StartCoroutine (FadeRoutine (side));
//	}

	IEnumerator FadeTo()
	{
		StartCoroutine("FadeRoutine",true);
		yield return new WaitForSeconds(0.8f);
		StartCoroutine("FadeRoutine",false);
	}

	IEnumerator FadeRoutine (bool side)
	{
		float t = 0.8f;

		while (t > 0) {
			t -= Time.deltaTime;
			if (side)
				SetAlphas (1 - t / Time.time);
			else
				SetAlphas (t / Time.time);
			yield return null;
		}
	}

	void SetAlphas (float alpha)
	{
		foreach (var item in spriteRenderes) {
			item.color = Color.Lerp (Color.white, Color.clear, alpha);
		}
	}
}
