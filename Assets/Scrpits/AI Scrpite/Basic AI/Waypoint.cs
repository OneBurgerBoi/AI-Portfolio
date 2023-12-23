using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    

    public GameObject[] wayPoint; // to store and mulpitalt data of the Way points the box mean more the one like a list 
    public GameObject enemy; // to store and mulpitalt data of the game object AI
    private float enemySpeed = 6f; // to store and mulpitalt data of the AI speed

    private int currentPoint = 0; // to store and mulpitalt data of the current way point 

    private float pointRadius = 1;// to store and mulpitalt data of the way point radius 



    // Update is called once per frame
    void Update()
    {


        WayPoint(); // the waypoint fuchtion 


    }

    private void WayPoint() // the waypoint/pathfinding fuchion 
    {



        if (Vector3.Distance(wayPoint[currentPoint].transform.position, transform.position) < pointRadius) // to find whe distance of the waypoint transform poition is greater then point radius  
        {
             

            currentPoint++; // this keep on add one to the way point on to update the current waypoint  


        }

        if (currentPoint >= wayPoint.Length) // if the current point greater then or equal to the way point 
        {
            currentPoint = 0; // make it loop back around to the start 



        }


        transform.position = Vector3.MoveTowards(transform.position, wayPoint[currentPoint].transform.position, Time.deltaTime * enemySpeed);
        // this is to move to the diffrent point by move the transform position 
    }

    private void OnCollisionEnter(Collision collision)// this fuchtion for if the game obejct colides with other game obejct with coliders 
    {
        if (collision.gameObject.tag == "Player") // if colide wit ha game obejct called player 
        {

            GameObject.FindWithTag("Player").GetComponent<HealthScrpite>().health -= 100f; // fine the player obejct throw called tag player and get the component of the healt health scrpti and take 100 health point way from the player 
        }



    }
}
