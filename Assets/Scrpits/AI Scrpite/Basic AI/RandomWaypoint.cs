using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWaypoint : MonoBehaviour
{
    public GameObject[] wayPoint; // to store and mulpitalt data of the Way points  the box mean more the one like a list 
    public GameObject enemy; // to store and mulpitalt data of the  game object of the AI
    private float enemySpeed = 4f; // to store and mulpitalt data of the AI speed

    private int currentPoint = 0; // to store and mulpitalt data of the current way point 

    private float pointRadius = 1; // to store and mulpitalt data of the way point radius 



    // Update is called once per frame
    void Update()
    {


        Rwaypoint(); // to call on the random waypoint fuchion 

       

    }


    private void Rwaypoint() // the random waypoint fuchion 
    {
        if (Vector3.Distance(wayPoint[currentPoint].transform.position, transform.position) < pointRadius) // moving to the way point 
        {
            currentPoint = Random.Range(0, wayPoint.Length); //going to a random way point 




        }

        if (currentPoint >= wayPoint.Length) // if the current point greater then or equal to the way point 
        {
            currentPoint = 0; // make it loop back around 



        }


        transform.position = Vector3.MoveTowards(transform.position, wayPoint[currentPoint].transform.position, Time.deltaTime * enemySpeed);
        // this is to move to the diffrent point by move the transform position 
    }

}


