using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook3D : MonoBehaviour
{
    public Transform eyes;

    Enemy enemy;
    
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public bool Look()
    {
        RaycastHit hit;

        Debug.DrawRay(eyes.position, eyes.forward.normalized * enemy.lookRange, Color.green);

        if (Physics.SphereCast (eyes.position, enemy.sphereRadius, eyes.forward,out hit, enemy.lookRange) && hit.transform.CompareTag ("Player"))
        {
           return true;
        }
        else
        {        
              return false;
        }

    }
      
}
