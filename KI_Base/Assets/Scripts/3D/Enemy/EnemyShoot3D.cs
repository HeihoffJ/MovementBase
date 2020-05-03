using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot3D : MonoBehaviour
{
    private float timeBtwShoots;
    public float startTimeBtwShoots;

    public float shootRange;
    //public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;

    }

    public void Shoot()
    {
        if (timeBtwShoots <= 0)
        {
            //Instantiate(projectile,transform.position, Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange) && hit.collider.CompareTag("Player"))
            {
                Debug.Log("execute SHoot");
                timeBtwShoots = startTimeBtwShoots;
            }
        }
        else
            timeBtwShoots -= Time.deltaTime;
    }
}
