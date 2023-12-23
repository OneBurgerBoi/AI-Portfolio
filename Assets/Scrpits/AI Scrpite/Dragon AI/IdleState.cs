using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private float timer; // // to store and mulpitalt data of the timer 

    Transform player;// to store and mulpitalt data of the player transform 

    private float chaseRange = 8; // to store and mulpitalt data of the chase range hwo far it can chase the player 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0; // timer equals zero 

        player = GameObject.FindGameObjectWithTag("Player").transform; //  to find the player object by finding the tag called player 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime; // timer add and equal to time .delta .time to do with farms 
        if(timer > 1.5) // to check if the AI has been idle for more then 1.5   
        {
            animator.SetBool("IsProtrolling", true); // set the bool is protrolling peramater to true in the animator // which set of the protorlling animation 

        }

        float distance = Vector3.Distance(player.position, animator.transform.position); //to calculate the distance to the player from the AI 
        if (distance < chaseRange) // to check if the player close to chase 
        {
            animator.SetBool("IsChasing", true); //set the bool is chasing peramater to true in the animator // which set of the chasing animation   

        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that sets up animation IK (inverse kinematics)
    }
}
