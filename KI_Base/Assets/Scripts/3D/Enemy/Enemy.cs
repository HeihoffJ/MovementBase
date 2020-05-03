using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float retreatHealth;
    EnemyLook3D enemyLook3D;
    EnemyPatrouillie3D enemyPatrouillie3D;
    EnemyRetreat3D enemyRetreat3D;
    EnemySeek3D enemySeek3D;
    EnemyShoot3D enemyShoot3D;
    
    bool enemySeen=false;
    bool readyToShoot=false;
    void Start()
    {
        enemyLook3D = GetComponent<EnemyLook3D>();
        enemyPatrouillie3D = GetComponent<EnemyPatrouillie3D>();
        enemyRetreat3D = GetComponent<EnemyRetreat3D>();
        enemySeek3D = GetComponent<EnemySeek3D>();
        enemyShoot3D = GetComponent<EnemyShoot3D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyLook3D.Look())
        enemySeen = true;
        else
        {
              enemySeen=false;
              enemyRetreat3D.Retreat();
        }
      
        if (CheckHealth())
            enemyRetreat3D.Retreat();
        else if (!enemySeen)
        {
            enemyPatrouillie3D.Patrouillie();
            Debug.Log("ich soll hier nicht rein");
        }
        else if (enemySeen)
            enemySeek3D.SeekPlayer(ref readyToShoot);

        if(readyToShoot)
            enemyShoot3D.Shoot();      

    }

    bool CheckHealth()
    {
        if (health <= health * retreatHealth / 100)
            return true;
        else
            return false;
    }
    void LooseHealth(float val)
    {
        health -= val;
        if (Input.GetKeyDown("space"))
        {
            health -= 10;
            Debug.Log(health);
        }
        if (health <= 0)
            Destroy(this);
    }
}
