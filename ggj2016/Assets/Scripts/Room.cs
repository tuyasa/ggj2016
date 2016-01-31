using UnityEngine;
using System.Collections;
using System;

public class Room : MonoBehaviour {
    public Bounds _bounds;
    Bounds bounds {
        get {
            if(_bounds.size == Vector3.zero)
                _bounds = GetBounds();

            return _bounds;
        }
    }

    private Bounds GetBounds()
    {
        Bounds b = new Bounds(transform.position,Vector3.zero);
        Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
            b.Encapsulate(r.bounds);

        return b;
    }

    public bool isInside(Vector2 pos)
    {
        return bounds.Contains(pos);
    }
    
}
