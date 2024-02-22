using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    MOVE,
    ATTACK,
    DIE
}

public class Metalon : MonoBehaviour
{
    private int health;
    public int Health
    {
        set { health = value; }
        get { return health; }
    }

    [SerializeField] State state;
    [SerializeField] Transform turretPosition;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    void Start()
    {
        health = 100;

        animator = GetComponent<Animator>();
        turretPosition = GameObject.Find("Turret Tower").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.MOVE: Move();
                break;
            case State.ATTACK: Attack();
                break;
            case State.DIE: Die();
                break;
        }
        Move();
    }

    public void Move()
    {
        navMeshAgent.SetDestination(turretPosition.position);
    }

    public void Attack()
    {
        animator.SetBool("Attack", true);
    }

    public void Die()
    {
        animator.Play("Die");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turret Tower"))
        {
            state = State.ATTACK;
        }
    }
}
