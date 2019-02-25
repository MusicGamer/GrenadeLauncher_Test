using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRaycast
{
    private float distance;

    public float GetDistance(Ray ray)
    {
        if (ray.direction.x >= 0)
        {
            distance = ray.origin.y / Mathf.Cos(Vector3.Angle(new Vector3(0, ray.origin.x * -1, 0), ray.direction) * Mathf.Deg2Rad);
        }
        else
        {
            distance = ray.origin.y / Mathf.Cos((180 - Vector3.Angle(new Vector3(0, ray.origin.x * -1, 0), ray.direction)) * Mathf.Deg2Rad);

        }
        return Mathf.Abs(distance);
    }
}
