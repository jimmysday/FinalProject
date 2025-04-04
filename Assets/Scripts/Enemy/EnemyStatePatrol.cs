using UnityEngine;

public class EnemyStatePatrol : EnemyStateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemy.DetermineNextWaypoint();
        enemy.Agent.SetDestination(enemy.GetCurrentWaypoint());
        Debug.Log("distance: " + enemy.Agent.remainingDistance);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("distance: " + enemy.Agent.remainingDistance);
        //Debug.Log("stoppingDistance: " + enemy.Agent.stoppingDistance);
        if (!enemy.Agent.pathPending)
        {
            Debug.Log("Updated distance: " + enemy.Agent.remainingDistance);
  
            if (enemy.Agent.remainingDistance <= enemy.Agent.stoppingDistance)
            {
                Debug.Log("set to idle");

               animator.SetTrigger("idle");
        }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
