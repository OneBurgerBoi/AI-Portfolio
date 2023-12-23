using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScrpite : MonoBehaviour
{
    public float health; // store and manipulate daat about the player health
    public float maxHealth; // store and manipulate daat about the player max health 

    public Transform rPoint; // store and manipulate daat about the transform respwan point 

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; // health is set to max health when start 

    }

    // Update is called once per frame
    void Update()
    {
        if (health<= 0) //check if the player heath is zero 
        {
            
            
            
            RespawnPlayer(); // call on the respwan fuchtion
        }

        

    }

    private void FixedUpdate()
    {
        if (health> maxHealth) // check if the health less then max health 
        {

            health = maxHealth; // player health equal to max healt h
        }
        else if (health < maxHealth) //if not 
        {

            health += 0.00001f; // health plus equal 0.00001f 
        }
    }

    private void RespawnPlayer() // the respawn fuchtion 
    {
        transform.position = rPoint.position; // the player transform = respwan position 

        health = maxHealth; // health equal max health 
    }

    private void OnTriggerEnter(Collider other) // if collides with game obejct with collide set to trigger 
    {

        if(other.tag == "clarw") // check if coldies with tag clarw 
        {
            health -= 50f; // take health of the player health
           
        }
    }


}
