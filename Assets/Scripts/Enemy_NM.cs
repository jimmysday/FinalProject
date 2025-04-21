using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy_NM : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;    // for moving on the NavMesh
    [SerializeField] private Transform target;      // the target to follow

    private float distanceToTarget = float.MaxValue;    // distance to target - default to far away
    private float chaseRange = 4f;                     // when target is closer than this, chase!
    private float attackRange = 1f;

    private enum EnemyState { IDLE, CHASE };
    private EnemyState state;

    private float health;
    private float maxHealth = 200f;
    [SerializeField] private Image healthFill; // Drag the Fill Image here in the Inspector

    //void Update()
    //{
    //    agent.SetDestination(target.transform.position);  // follow the target
    //}
    private void SetState(EnemyState newState)
    {
        state = newState;
    }

    void Start()
    {
        SetState(EnemyState.IDLE);      // start off in the IDLE state
        health = 200f;
    }

    void Update()
    {
        CalculateAnimVelocity();
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        // what happens here depends on the state we're currently in!
        switch (state)
        {
            case EnemyState.IDLE: Update_Idle(); break;
            case EnemyState.CHASE: Update_Chase(); break;
            default: Debug.Log("Invalid state!"); break;
        }
    }

    void Update_Idle()
    {
        agent.isStopped = true;                             // stop the agent (following)
        if(distanceToTarget <= chaseRange)
        {
            SetState(EnemyState.CHASE);
        }
    }

    void Update_Chase()
    {
        agent.isStopped = false;                            // start the agent (following)
        agent.SetDestination(target.transform.position);    // follow the target
        if(distanceToTarget > chaseRange)
        {
            SetState(EnemyState.IDLE);
        }
        if(distanceToTarget <= attackRange)
        {
            //Debug.Log("enemy attacking player");
            anim.SetBool("isnear",true);
        }

        if(distanceToTarget > attackRange)
        {
            anim.SetBool("isnear", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);  // draw a circle to show chase range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Unused for now, but if later, you want to add animations, call this to determine velocity param for a 1D blend tree.
    void CalculateAnimVelocity()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);  // calculate % of full speed agent is moving
//        Debug.Log("agent.velocity.magnitude" + agent.velocity.magnitude);
    }

    public void TakeDamage(float amount)
    {
        //        Debug.Log("update 1 health: " + archorHealth);
        health -= amount;
        if (health > 0)
        {
            //anim.SetTrigger("Hit");
            Debug.Log("update 2 health: " + health);
            //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (healthFill != null)
            {
                Debug.Log("tackeDamage: " + health);
                healthFill.fillAmount = health / maxHealth;
            }
        }
        else
        {
            if (healthFill.fillAmount > 0)
            {
                anim.SetTrigger("death");
                healthFill.fillAmount = 0;
                Messenger.Broadcast(GameEvent.DEATH_ARCHOR);
            }
        }

    }
    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}
