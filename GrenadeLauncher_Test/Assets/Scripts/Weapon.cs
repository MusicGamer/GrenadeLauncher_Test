using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public Transform firePoint;
    public GameObject bullet;
    public float fireRate = 5f;
    public bool isReload;

    private int armor = 5;  
    private float timeToFire = 0f;
    private PlayerController pc;

    private void Start()
    {
        pc = gameObject.GetComponentInParent(typeof(PlayerController)) as PlayerController;
    }

    void Update()
    {       
        if (isReload)
        {
            return;
        }
        if (armor == 0)
        {
            StartCoroutine(Reload());
            return;
        } 
    }

    public void Shoot(Transform target)
    {
        if (Time.time >= timeToFire)
        {
            Grenade grena = Instantiate(bullet, firePoint.position, transform.rotation).GetComponent<Grenade>();
            pc.animator.Play("assault_combat_shoot"); 
            grena.target = target;
            armor--;
            timeToFire = Time.time + 1f / fireRate;
        }      
    }

    IEnumerator Reload()
    {
        isReload = true;
        yield return new WaitForSeconds(10);
        armor = 5;
        isReload = false;
    }
}
