using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrpite : MonoBehaviour
{
    private float bulletSpeed = 5; // to store & manipulate the bullet speed 

    public Rigidbody rb;// to store & manipulate the rigidbody  

    public AIController myAI;// to store & manipulate the AI 

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>(); // to get the component of  the AI Rigidbody 

        myAI = GetComponent<AIController>(); // to get the component of the AI controller script 



    }

    // Update is called once per frame
    void Update()
    {
        BulletController(); // to call the Bullet controller method 
    }

    private void BulletController() // the bullet controller method 
    {


        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, bulletSpeed); // the bullet movement 

        Destroy(gameObject, 0.5f); // to destroy the game object 


    }

    private void OnCollisionEnter(Collision collision) // if the game object collide 
    {
        if (collision.gameObject.tag == "Player") // if the object bullet colldies with an object that tag player 
        {

            

            GameObject.FindWithTag("Player").GetComponent<HealthScrpite>().health -= 100f; //   to take 100 health point kill the player by fiding the tag object player and getting the component of the healt hscrpite
        }



    }

}
