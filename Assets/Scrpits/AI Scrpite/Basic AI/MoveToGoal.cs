using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    

    private float eSpeed = 9f; //to store and manipulate data of the the enemy speed
    public Transform tGoal; //to store and manipulate data of the Goal
    public float enemyAccuracy = 1f;//to store and manipulate data of the enemy Accuracy // 2 or 3 good for buddy AI
    public AudioSource hurt;  //to store and manipulate data of the hurt audio sound 


    // Start is called before the first frame update
    void Start()
    {
        hurt = GetComponent<AudioSource>(); // hurt is the get component of the audio source in the AI

    }

    // Update is called once per frame
    void Update()
    {
        MTG(); // to all on the move to goal fuchtion 



    }


    private void MTG() // the move to goal fuchtion 
    {

        this.transform.LookAt(tGoal.position); //to make the AI look at the goal 

        Vector3 direction = tGoal.position - this.transform.position; // to calculate the direction of where the AI is going to go 

        Debug.DrawRay(this.transform.position, direction, Color.red); // this draw a line to the goal from the AI

        if (direction.magnitude > enemyAccuracy) //if the diraction is greater then the enemy accuracy 
        {
            this.transform.Translate(direction.normalized * eSpeed * Time.deltaTime, Space.World); // to move the AI to the go with using the tramfomr 
           




        }

    }

    private void OnCollisionEnter(Collision collision) // this fuchtion is when the game obejct attach to this scrpit colide with another game objec twit ha coldier 
    {
        if (collision.gameObject.tag == "Player") // if collides with game obejc twit htag Player 
        {
            Debug.Log("work"); // then a debug log come up saying work 

            hurt.Play(); //t o play the hurt sound effect 

            //this.transform.GetComponent<Renderer>().material.color = Color.green; //to change colour when collides 

            //Destroy(collision.gameObject, 0.5f); // destroys the game object 

            GameObject.FindWithTag("Player").GetComponent<HealthScrpite>().health -= 100f; // t otake healt hpoint from the player by finding the tag player and getting the health scrpite


        }
    }
}
