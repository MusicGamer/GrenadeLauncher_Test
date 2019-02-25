using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Transform target; public float radius = 2;
    public float damage = 20f;
    public float bulletSpeed = 10f;

    private float startAngle;
    private Vector3 startVector;
    private Vector3 targetVector;
    private float speedDown = 2f;
    private float flyTime;
    private float startDistance;
    private const float gravity = 9.81f;
    private int amountOfJump = 3;
    

    void Start()
    {
        targetVector = target.position;
        startVector = transform.position;
        startDistance = GetDistance(targetVector);
        startAngle = StartAngle(startVector.y - 00.2f);
    }

    void FixedUpdate()
    {
        float xz = startDistance - GetDistance(targetVector);
        Vector3 pos = new Vector3(targetVector.x, 0, targetVector.z);
        transform.position = Vector3.MoveTowards(transform.position, pos, bulletSpeed * Time.deltaTime);
        float y = startVector.y + xz * Mathf.Tan(startAngle) - (gravity / (2 * Mathf.Pow(bulletSpeed, 2) * Mathf.Pow(Mathf.Cos(startAngle), 2))) * Mathf.Pow(xz, 2);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        if (transform.position.x == targetVector.x && transform.position.z == targetVector.z)
        {
            startDistance /= 2;
            targetVector = targetVector + (transform.forward.normalized * startDistance);
            startVector.y = 0.2f;
            startAngle = StartAngle(0);
            amountOfJump -= 1;
            GameController.instance.DamageEnemies(transform.position, radius, damage);
        }
        if (amountOfJump == 0)
        {
            GameController.instance.DamageEnemies(transform.position, radius, damage);
            Destroy(gameObject);
        }
    }

    private float GetDistance(Vector3 target)
    {
        Vector3 targetVector = target - transform.position;
        targetVector.y = 0f;
        return targetVector.magnitude;
    }
    private float StartAngle(float h)
    {
        float denominator = (0.5f * gravity * Mathf.Pow(startDistance, 2)) / Mathf.Pow(bulletSpeed, 2);
        float b = startDistance / denominator;
        float c = 1 - (h / denominator);
        float D = Mathf.Pow(b, 2) - 4 * c;
        float x = (b - Mathf.Sqrt(D)) / 2;

        // Taectory mortira:
        //float x = (b + Mathf.Sqrt(D)) / 2;

        return Mathf.Atan(x);
    }

}
