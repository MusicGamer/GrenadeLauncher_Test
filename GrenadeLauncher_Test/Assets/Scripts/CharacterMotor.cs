using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMotor : MonoBehaviour
{

    NavMeshAgent nmAgent;

    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>(); 
    }

    public void MoveCharacter (Vector3 point)
    {
        nmAgent.SetDestination(point);
    }
}
