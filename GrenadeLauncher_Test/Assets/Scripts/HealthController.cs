using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health = 100;
    public Image healthBar;
    private float startHealth;

    private void Start()
    {
        startHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Destroy(gameObject.gameObject);
            GameController.instance.CreateEnemy();
        }
    }
}
