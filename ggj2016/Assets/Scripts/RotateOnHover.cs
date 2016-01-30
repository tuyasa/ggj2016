using UnityEngine;
using System.Collections;

public class RotateOnHover : MonoBehaviour {

    RectTransform rTransform;
    bool over = false;

    public void OnEnable()
    {
        rTransform = gameObject.GetComponent<RectTransform>();
        rTransform.rotation = Quaternion.identity;
    }


	public void OnMouseOver()
    {
        over = true;
        StartCoroutine(Rotate());
    }

    public void OnMouseLeave()
    {
        over = false;
        StartCoroutine(Rotate());

    }

    IEnumerator Rotate(float time = 0.4f)
    {
        float rotation = 0;
        while(over || rotation > 0)
        {
            if (over && rotation < 10)
            {
                rotation += Time.unscaledDeltaTime * 40;
                rTransform.rotation = Quaternion.Euler(0, 0, rotation);
            }
            else if(!over) {
                rotation += Time.unscaledDeltaTime * -40;
                rTransform.rotation = Quaternion.Euler(0, 0, rotation);
            }
            yield return null;
        }

    }

}
