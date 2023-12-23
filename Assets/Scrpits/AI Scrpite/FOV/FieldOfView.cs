using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour //field of View
{

    //movment
    private float enemySpeed = 3; // to store and mulpitalt data of the enemy speed 
    public Transform player; // to store and mulpitalt data of the player transform  

    public GameObject[] wayPoint; // to store and mulpitalt data of the waypoints the box mean more the one like a list 
    public GameObject enemy; // to store and mulpitalt data of the game object enimey 

    private int currentPoint = 0;// to store and mulpitalt data of the current way point 

    private float pointRadius = 1; // to store and mulpitalt data of the way point radius 

    // setting up the range of view 
    public float radius; // to store and mulpitalt data of the radius 
    [Range(0, 360)] // the range it aloud to be 
    public float angle; // // to store and mulpitalt data of the AI viseon angle 

    public GameObject playerRef; // // to store and mulpitalt data of the about the player 

    // to hold and manipulate the data of the layer mask 
    public LayerMask tragetMask; // to store and mulpitalt data of the trager mask
    public LayerMask obstacleMask;// to store and mulpitalt data of the the obstacle mask

    public bool seePlayer; // to store and mulpitalt data of the bool about seeing the player 

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player"); //the player refcrece is the gaem obejct that is tag player 

        StartCoroutine(FOVRoutine()); // to start the coroutine for the FOV routine 

    }

    // Update is called once per frame
    void Update()
    {
        
        if(seePlayer == true) // if the AI see the player 

        {
            Vector3 direction = player.position - this.transform.position; // to find the direction of where the AI will be going 

            this.transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World); //to make the AI move using the trasfomr 

            this.transform.LookAt(player.position); // to look at the player 
        }
        else
        {
            Pathfinding(); // to call the method  called pathfinding 

        }
         

    }

    /// <summary>
    ///  the Routtie will start when teh FOV check get trigger 
    /// </summary>
    /// <returns></returns>
    /// 

  

    public IEnumerator FOVRoutine() // IEnumerator is fuchion to make it set at the some time 
    {

        WaitForSeconds wait = new WaitForSeconds(0.2f); // to wait around 0.2 secons 

        while (true)
        {

            yield return wait;
            FOVCheck(); // call on the FOV check 

        }

    }


    public void FOVCheck() // the field of view check fuchintion 
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, tragetMask);// the to check the range of the enemy 


        if (rangeCheck.Length != 0) //if  range  is not = 0
        {

            Transform traget = rangeCheck[0].transform; //  the transform traget is the range check 0 transform 

            Vector3 directionToTarget = (traget.position - transform.position).normalized; // the vetor 3 direction to target is the player position - the enimey postion 

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) // if the angle is the forward direction to target  less the nteh angle and devied by 2
            {
                float disancetoTarget = Vector3.Distance(transform.position, traget.position); //the float disanceto traget = the X,Y,Z axis wich is teh AI piont and the player point 

                if (!Physics.Raycast(transform.position, directionToTarget, disancetoTarget, obstacleMask)) // if no physics ray cast and what in the raycast
                {
                    seePlayer = true; // if it sees player

                }              
                else
                {
                    seePlayer = false;// dose not see player 

                }
                    
                                   

            }

            else // not in the view  of player 
            {
                seePlayer = false; // can not see player so set to false 
            }

             

        }
        else if (seePlayer) // else  if it see player 
        {

            seePlayer = false; // then  see player is false 



        }

    }

    private void OnCollisionEnter(Collision collision) // if object colide with another object that has collider 
    {
        if (collision.gameObject.tag == "Player") // if the game obejct is tag player 
        {

            

            GameObject.FindWithTag("Player").GetComponent<HealthScrpite>().health -= 100f; // find the player ans get the health scrpit component and - 100 hp from the player
        }



    }

    private void Pathfinding()
    {
        if (Vector3.Distance(wayPoint[currentPoint].transform.position, transform.position) < pointRadius) // moving to teh way point 
        {
            //currentPoint = Random.Range(0, wayPoint.Length); //going to a random way point 

            currentPoint++; // this keep on add one to the way point o maove it to the next one 


        }

        if (currentPoint >= wayPoint.Length) // if the current point greater tehn or equal to the way point 
        {
            currentPoint = 0; // make it loop back around 



        }


        transform.position = Vector3.MoveTowards(transform.position, wayPoint[currentPoint].transform.position, Time.deltaTime * enemySpeed);
        // this is to move to the diffrent point by move teh transform position 



    }
}
