using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek3D : MonoBehaviour
{
    private Transform player;

    public int speed = 4;
    public int maxDist = 10;
    public int minDist = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        SeekPlayer();
    }

    /// <summary>
    /// Look at player and move towards him till min minDist is reached
    /// use maxDist to start shooting for example if > just move
    /// </summary>
    void SeekPlayer()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= maxDist)
            {
                //
            }

        }
    }
}
