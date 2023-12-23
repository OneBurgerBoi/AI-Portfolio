using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // to use unity AI manager 

public class PartrollingState : StateMachineBehaviour
{
    private float timer; // to store and manipulate the timer 

     List<Transform> wayPoints = new List<Transform>(); // to store and manipulate the list of the transfer waypoint make a new list tranfroms 

    NavMeshAgent agent; //to store and manipulate the nave mash agent   

    Transform player; //to store and manipulate the the player transform

    private float chaseRange = 8; //to store and manipulate the chase range 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>(); // to get the component NavMshAgent from the AI

        player = GameObject.FindGameObjectWithTag("Player").transform; // find th game obejct tramform that has the tag of player 

        agent.speed = 1.5f; // the agent.speed is 1.5 

        timer = 0; // timer equal zero 
        
        GameObject go = GameObject.FindGameObjectWithTag("Waypoints"); //  the game object called go is the find game object  tag WAypoint s ot ofind every thing that been tag waypoint 
        foreach (Transform t in go.transform) // for each transform in go transform
        {
            wayPoints.Add(t); // go to the next way point 
        }
            

        agent.SetDestination(wayPoints[Random.Range(1, wayPoints.Count)].position); // agent set denination to a random waypoint that been set 
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        if(agent.remainingDistance <= agent.stoppingDistance) // if agant remaining distance more then or equal t oagant stopping distance 
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position); // agent .set distande is a random way point position 
        }

        timer += Time.deltaTime; // the timeer + = to delta time 
        if (timer > 10) // to ckeck if the AI been patrolling more then 10 seconds 
        {
            animator.SetBool("IsProtrolling", false); // st the isProtolling to false 

        }


        float distance = Vector3.Distance(player.position, animator.transform.position); // to calculate the distance bwten the AI poition and the AI position 
        if (distance < chaseRange) // check if the player close to chase 
        {
            animator.SetBool("IsChasing", true); // set off the bool is chaseing peramatior to true  to trigger the animation 

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position); // set agent destation to the agant position to it stop moving 
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
