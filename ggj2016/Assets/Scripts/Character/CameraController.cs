using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public bool lockCamera;
    bool cameraStatus = true;//False = Out, True = In // We start zoomed in
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!lockCamera)
			transform.position = target.position + -50 * Vector3.forward + Vector3.up;

        if(Input.GetKeyDown(KeyCode.C))
        {
            if (cameraStatus) StartCoroutine(ZoomOut());
            else StartCoroutine(ZoomIn());
        }
    }

    public IEnumerator ZoomOut(float time = 1f)
    {
        cameraStatus = false;
        float t = time;
        while (t > 0)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 8,1-(t/time));
            t -= Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator ZoomIn(float time = 1f)
    {
        cameraStatus = true;
        float t = time;
        while (t > 0)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2, 1 - (t / time));
            t -= Time.deltaTime;
            yield return null;
        }
    }

}
