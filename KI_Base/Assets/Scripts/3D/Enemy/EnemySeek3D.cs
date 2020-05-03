using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemySeek3D : MonoBehaviour
{
    private Transform player;
    private Transform eyes;

    NavMeshAgent agent;
    public int speed = 4;
    public int maxDist = 10;
    public int minDist = 2;
    Vector3 lastPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        eyes = GameObject.FindGameObjectWithTag("Eyes").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Look at player and move towards him till min minDist is reached
    /// use maxDist to start shooting for example if > just move
    /// </summary>
    public void SeekPlayer(ref bool readyToShoot)
    {
        transform.LookAt(player);
        eyes.LookAt(player);

        Debug.Log("seeking enemy");
        readyToShoot = false;
        if (player.position != lastPosition)
        {
            agent.SetDestination(player.position);
            lastPosition = player.position;
        }


        if (Vector3.Distance(transform.position, player.position) <= maxDist)
        {
            readyToShoot = true;
        }

    }
}

