using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //bullet virables 
    public Transform firePoint; // to store & manipulate data about the fire point position 
    public GameObject myBullet; // to store & manipulate data about the bullet prefab 


    public Transform player;  // to store & manipulate data about the player transform 
    private Animator anim; //  // to store & manipulate data about the about the Animator 

    //Enemy data types 
    private float enemySpeed = 2f;  // to store & manipulate data about theenemyu speed 
    private float rotationSpeed = 2.0f;  // to store & manipulate data about the rotation speed 
    private float visDist = 20.0f;  // to store & manipulate data about the distance the AI Sees 
    private float visAngle = 30.0f; // to store & manipulate data about the angle the AI sees
    private float shootDist = 5.0f; // to store & manipulate data about the how far the AI can be to Shoot 

    /// <summary>
    /// the way points 
    public GameObject[] wayPoint;  // to store & manipulate data about the way points and the box mean more the one like a list 
    public GameObject enemy;  // to store & manipulate data about the enemy game object 

    private int currentPoint = 0;  // to store & manipulate data about the current point integer 
       
    private float pointRadius = 1;  // to store & manipulate data about the point raidus 

    // the sound data type 
    public AudioSource shoot;   // to store & manipulate data about the Shoot Audio sound 

    string state = "IDLE"; // so befor the game load it state at an idle state 
    // Start is called before the first frame update
    void Start()
    {

        anim = this.GetComponent<Animator>(); // to get the component of the animator 

        shoot = GetComponent<AudioSource>(); // to get the component of the audio sorece 

    }

    // Update is called once per frame
    void Update() 
    {
        AIEventSystem(); // to call on the AI event Systems 
    }

    private void AIEventSystem() // the AI Event system methoud 
    {

        Vector3 direction = player.position - this.transform.position; // the direction is the player poition - the AI position 
        float angle = Vector3.Angle(direction, this.transform.forward); //the angle is direction, and AI transform forward 


        if (direction.magnitude < visDist && angle < visAngle) //if the direction is less then the AI can see them 
        {
            direction.y = 0; // direction of the y axes is set to 0 

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed); 
            // the AI rotation is calculate wit ha quaternion that incules tha AI rotation and look rotatiom direction and time dalta ime by the rotation speed 

            if (direction.magnitude > shootDist) // if the it see the player can close 
            {
                if (state != "RUNNING") // if its state not set to run 
                {
                    state = "RUNNING"; // set the state to running
                    anim.SetTrigger("isRunning"); // and player the is running trigger pramator in the animator 
                }
            }
            else // esle then shoot if it really close 
            {
                if (state != "SHOOTING") // if the state not shooting 
                {
                    state = "SHOOTING"; // set state shooting 
                    anim.SetTrigger("isShooting"); // set of the is shooting triggre pramitor in the animator 
                }
            }
        }
        else // else if it can see the player 
        {
            if (state != "IDLE") // if the state is not set to idle 
            {
                state = "IDLE"; // set the state to idle 
                anim.SetTrigger("isIdle"); // and set of the is idle trigger pramitor in the animator 





            }
        }
        if (state == "RUNNING") // if state is running 
        {
            this.transform.Translate(0, 0, Time.deltaTime * enemySpeed); // to make the AI move 



        }

        if (state == "SHOOTING") // if the state is shooting 
        {

            shoot.Play(); // play the shooting aniamtion 


        

            Instantiate(myBullet, firePoint.position, firePoint.rotation); // to shoot the brefabe bullet from the firing place 

        }

        if (state == "IDLE") // if the state is idle 
        {
            if (Vector3.Distance(wayPoint[currentPoint].transform.position, transform.position) < pointRadius) // moving to teh way point 
            {
                //currentPoint = Random.Range(0, wayPoint.Length); //going to a random way point 

                currentPoint++; // this keep on add one to the way point o maove it to the next one 

                anim.SetTrigger("isRunning"); // play the running animation 

            }

            if (currentPoint >= wayPoint.Length) // if the current point greater then or equal to the way point 
            {
                currentPoint = 0; // make it loop back around 



            }

            transform.position = Vector3.MoveTowards(transform.position, wayPoint[currentPoint].transform.position, Time.deltaTime * enemySpeed); // to make it move to the point by make the traform to current waypoitnt 


            // this.transform.LookAt(currentPoints.position); // to look at the point 
        }
    }

    private void OnCollisionEnter(Collision collision) // if collide with anything with a colider 
    {
        if (collision.gameObject.tag == "Player") // if it collide with game obejct with tag player 
        {

            

            GameObject.FindWithTag("Player").GetComponent<HealthScrpite>().health -= 100f; // find gamobject with tag and get the component of the health scrpit and take 100f from the player health 
        }



    }

}
    



