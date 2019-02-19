using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRaycast
{
    private float distance;

    public float GetDistance(Ray ray)
    {
        distance = ray.origin.y / Mathf.Abs(Mathf.Cos(Vector3.Angle(new Vector3(ray.origin.x, ray.origin.y, 0), ray.direction) * Mathf.Deg2Rad));
        return distance;
    }
}
