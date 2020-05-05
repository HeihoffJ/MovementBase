using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrouillie3D : MonoBehaviour
{
    EnemyLook3D enemyLook3D;
    public Vector3[] localWayPoints;
    Vector3[] globalWayPoints;

    Vector3 lastPosition;
    public bool cyclic;
    public float waitTime;
    [Range(1, 3)]
    public float easeValue = 1;
    int fromWayPointIndex;
    float percentBetweenWayPoints;
     private NavMeshAgent agent;
    float nextMoveTime;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        enemyLook3D = GetComponent<EnemyLook3D>();

        globalWayPoints = new Vector3[localWayPoints.Length];

        for (int i = 0; i < localWayPoints.Length; i++)
        {
            globalWayPoints[i] = localWayPoints[i] + transform.position;
        }

    }
    float Ease(float x)
    {

        return Mathf.Pow(x, easeValue) / ((Mathf.Pow(x, easeValue) + Mathf.Pow(1 - x, easeValue)));
    }

    public void Patrouillie()
    {
        if (Time.time < nextMoveTime)
            return;
        fromWayPointIndex %= globalWayPoints.Length;
        int toWayPointIndex = (fromWayPointIndex + 1) % globalWayPoints.Length;
        float distance = Vector3.Distance(globalWayPoints[fromWayPointIndex], globalWayPoints[toWayPointIndex]);
        percentBetweenWayPoints += Time.deltaTime * agent.speed / distance;
        percentBetweenWayPoints = Mathf.Clamp01(percentBetweenWayPoints);
        float easedPercent = Ease(percentBetweenWayPoints);

        Vector3 newPos = Vector3.Lerp(globalWayPoints[fromWayPointIndex], globalWayPoints[toWayPointIndex], easedPercent);

        if (percentBetweenWayPoints >= 1)
        {
            enemyLook3D.eyes.Rotate(0,180,0);
            percentBetweenWayPoints = 0;
            fromWayPointIndex++;

            if (!cyclic)
            {

                if (fromWayPointIndex >= globalWayPoints.Length - 1)
                {
                    fromWayPointIndex = 0;
                    System.Array.Reverse(globalWayPoints);
                }
            }

            nextMoveTime = waitTime + Time.time;
        }

        Vector3 movement = newPos ;// - transform.position;

         if (movement != lastPosition)
        {
            agent.SetDestination(movement);
            lastPosition = movement;
        }
    }
    void OnDrawGizmos()
    {
        if (localWayPoints != null)
        {
            Gizmos.color = Color.red;
            float size = .3f;

            for (int i = 0; i < localWayPoints.Length; i++)
            {
                Vector3 globalWaypointPos = (Application.isPlaying) ? globalWayPoints[i] : localWayPoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
            }
        }
    }
}
