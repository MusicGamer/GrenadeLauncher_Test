using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour
{
    Camera camera;

    CharacterMotor cMotor;
    CustomRaycast cr = new CustomRaycast();

    void Start()
    {
        camera = Camera.main;
        cMotor = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);          
            cMotor.MoveCharacter(ray.GetPoint(cr.GetDistance(ray)));
        }
    }
}
