using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckHealth3D : MonoBehaviour
{
    Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

   public bool CheckHealth()
    {
        if (enemy.health <= enemy.health * enemy.retreatHealth / 100)
            return true;
        else
            return false;
    }
}
