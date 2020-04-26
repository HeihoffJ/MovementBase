using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2D : MonoBehaviour
{
    public GameObject target;
    private Player player;

    // --- seek and follow player ---
    [Header("Movement")]
    private Vector2 movement;
    [SerializeField] private float speed = .8f;
    private bool _moveAble = true;

    public bool MoveAble
    {
        get => _moveAble;
        set => _moveAble = value;
    }

    float dist = Mathf.Infinity;                        // to calculate distance to player and stop when near to him

    [Header("Seek ")]
    private bool _seekPlayer = true;
    public bool SeekPlayer
    {
        set => _seekPlayer = value;
    }

    // --- attack ---
    [Header("Attack related")]
    [SerializeField] float attackRange = .9f;
    [SerializeField] float attackSpeed = 2.0f;
    [SerializeField] int damage = 1;
    private float attackCooldown;

    // --- animations & effects ---
    [SerializeField] private Animator animator;
    

    void Start()
    {
        //maybe null pointer abfangen
        target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<Player>();
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveAble) MoveTo();
    }


    void MoveTo()
    {   
        // calculate Distance to target
        dist = Vector2.Distance(this.transform.position, target.transform.position);
                
        // animation enable

        //move to
        if(_seekPlayer && dist > attackRange)
        {
            movement = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
            this.transform.position = movement;
        }
        else if(dist <= attackRange)
        {
            Attack();
        }

    }

    void Attack()
    {
        // animator.SetBool("isAttacking", true);
        attackCooldown -= Time.deltaTime;
        if(attackCooldown <= 0.0f)
        {
            attackCooldown = attackSpeed;
            //player.GetHit(damage);
        }
    }
}
