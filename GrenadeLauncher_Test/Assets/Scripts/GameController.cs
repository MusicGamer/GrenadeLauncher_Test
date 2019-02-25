using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    #region Singleton 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }           

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public GameObject[] enemies;
    public GameObject enemy;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }


    public void DamageEnemies(Vector3 bulletPos, float triggerRange, float damage)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && Vector3.Distance(bulletPos, enemies[i].transform.position) <= triggerRange)
            {
                enemies[i].GetComponent<HealthController>().TakeDamage(damage);
            }
        }
    }

    public void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20)), transform.rotation);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
