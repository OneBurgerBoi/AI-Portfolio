using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{
    public Animator anim; //store and manipulate data about the the animator

    public int HP = 100; // store and manipulate data about the Health points 
    

    public void TakeDamage(int damageAmout) //the take dame fuchtion 
    {
        HP -= damageAmout; //  to take health point from the damage amount  
        if(HP <= 0)
        {
            anim.SetTrigger("Die"); // play the death animation 
           // GetComponent<Collider>().enabled = false; // st the compoent collider and turn off the collider 
        }
        else
        {
            anim.SetTrigger("Damage");// play get hit animation 
            
        }

        if(HP >= 50)
        {
            anim.SetTrigger("Half"); // play the death animation 
            
        }

    }


}
