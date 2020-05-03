using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRetreat3D : MonoBehaviour
{
   public Transform retreatPos;
   private NavMeshAgent agent;
   Vector3 lastPosition;
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Retreat()
    {
           if (retreatPos.position != lastPosition)
        {
            agent.SetDestination(retreatPos.position);
            lastPosition = retreatPos.position;
        }
        
    }

}
