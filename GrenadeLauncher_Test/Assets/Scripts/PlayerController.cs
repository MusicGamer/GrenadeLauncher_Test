using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera camera;
    NavMeshAgent nmAgent;
    public Animator animator;
    CustomRaycast cr = new CustomRaycast();
    GameObject[] enemies;
    public float triggerRadius = 10f;
    Weapon weapon;
    private bool isRuning = false;

    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemies = GameController.instance.enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && Vector3.Distance(transform.position, enemies[i].transform.position) <= triggerRadius)
            {
                if (!weapon.isReload)
                {
                    transform.LookAt(enemies[i].transform);
                    weapon.Shoot(enemies[i].transform);                   
                }
            }
        }
    }

    public void MoveCharacter(Vector3 point)
    {
        nmAgent.SetDestination(point);
    }
}
