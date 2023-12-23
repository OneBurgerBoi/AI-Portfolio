using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
   

    public int damageAmount = 2; // to store and manipulate data about the damage amount 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f); // to destroy the game object 
    }

    

    private void OnTriggerEnter(Collider other) // that if the ballet colide wit ha colldier set to trigger 
    {
        if(other.tag == "Dragon") // if collides  tag dragon 
        {
            transform.parent = other.transform; //the parnt tramform is equal to the transform of the bullet 
            other.GetComponent<HealthScript>().TakeDamage(damageAmount); // get  the enemy healt hscrpit and take health point form them 
        }
    }
}