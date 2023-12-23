using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // to use unity AI manager 

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent; // to store and mulpitalt data of the nev mash agant 

    Transform player; //// to store and mulpitalt data of the player transofrom

    public float AISpeed = 3.5f; // to store and mulpitalt data of the AI Speed 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>(); //to get the AI component of the NavMeshAgent 

        player = GameObject.FindGameObjectWithTag("Player").transform; //to find the player object transfom by finding the tag called player 
        agent.speed = AISpeed;// the  agant speed is the AI speed 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position); // the AI destination is the player position 
        float distance = Vector3.Distance(player.position, animator.transform.position); //to calculate the distance of the player position to the AI position 
        if (distance > 11) //to check if the player is far from the AI to chase  
        {
            animator.SetBool("IsChasing", false); //set of the bool is is chasing permatiter to false in the animator 

        }
        if(distance <5f) //o check if the AI is close to attack 
        {
            animator.SetBool("IsAttacking", true); //set of the bool is attacking peramaiter to ture in the animator // which set of the attacking animation 
            GameObject.FindWithTag("clarw").GetComponent<Collider>().enabled = true; // the game object the is tag clarw and get the collider component and set it to true 
        } 
         
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position); // make it stop moving when exiting the state 
    }

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
