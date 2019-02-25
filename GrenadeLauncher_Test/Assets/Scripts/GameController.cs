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

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void RecalculateEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
