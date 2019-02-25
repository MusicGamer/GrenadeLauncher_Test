using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float triggerRadius = 10f;

    private Camera camera;
    private NavMeshAgent nmAgent;    
    private CustomRaycast cr = new CustomRaycast();
    private GameObject[] enemies;
    private Weapon weapon;
    private bool isRuning = false;

    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        camera = Camera.main;
        weapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        CheckEnemy();

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);          
            MoveCharacter(ray.GetPoint(cr.GetDistance(ray)));
        }
        if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
        {
            isRuning = false;
        }
        else
        {
            isRuning = true;
        }
        animator.SetBool("isRun", isRuning);

    }

    private void CheckEnemy()
    {
        enemies = GameController.instance.enemies;
        float distance = triggerRadius;
        GameObject crrentEnemy = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && Vector3.Distance(transform.position, enemies[i].transform.position) <= distance)
            {
                distance = Vector3.Distance(transform.position, enemies[i].transform.position);
                crrentEnemy = enemies[i];
            }
        }
        if (crrentEnemy != null && !weapon.isReload)
        {
            transform.LookAt(crrentEnemy.transform);
            weapon.Shoot(crrentEnemy.transform);
        }
    }

    public void MoveCharacter(Vector3 point)
    {
        nmAgent.SetDestination(point);
    }
}
