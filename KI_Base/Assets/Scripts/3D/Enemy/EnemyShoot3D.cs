using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot3D : MonoBehaviour
{
    private float timeBtwShoots;
    
    Enemy enemy;
    //public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        timeBtwShoots = enemy.startTimeBtwShoots;

    }

    public void Shoot()
    {
        if (timeBtwShoots <= 0)
        {
            //Instantiate(projectile,transform.position, Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, enemy.shootRange) && hit.collider.CompareTag("Player"))
            {
                Debug.Log("execute SHoot");
                timeBtwShoots = enemy.startTimeBtwShoots;
            }
        }
        else
            timeBtwShoots -= Time.deltaTime;
    }
}
