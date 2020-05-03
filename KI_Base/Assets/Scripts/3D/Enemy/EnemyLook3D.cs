using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook3D : MonoBehaviour
{
    public Transform eyes;
    public int lookRange;
    public float sphereRadius;
    void Start()
    {
        
    }

    public bool Look()
    {
        RaycastHit hit;

        Debug.DrawRay(eyes.position, eyes.forward.normalized * lookRange, Color.green);

        if (Physics.SphereCast (eyes.position, sphereRadius, eyes.forward,out hit, lookRange) && hit.transform.CompareTag ("Player"))
        {
           return true;
        }
        else
        {        
              return false;
        }

    }
      
}
