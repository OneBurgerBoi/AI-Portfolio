using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // to use unity input system 
using UnityEngine.SceneManagement; // to use unity scene manager 

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; //to store and manipulate data of the rigibody 
    public GameObject camHolder, myBullet; //to store and manipulate data of the bullet prefab and cam holder  
    public float speed, sensitivity, maxForce, jumpForce; //to store and manipulate data of the player speed, sensitivity, max force and jumo force 
    public Vector2 move, look; // //to store and manipulate data of the move and look vector 2 
    private float lookRotation, bulletSpeed = 5; // //to store and manipulate data of the look rotation and bullet speed 
    public bool isGrounded, hasKey; //to store and manipulate data of the has the player got the key and is grounded 

    public Transform firePoint; //to store and manipulate data of the  fire point 



    public void OnMove(InputAction.CallbackContext context) // to call the function on the impute system 
    {
        move = context.ReadValue<Vector2>();  // move is read value of vector 2 

    }

    public void OnLook(InputAction.CallbackContext context) // to call the function on the impute system 
    {
        look = context.ReadValue<Vector2>(); // look is read value  of a vector 2
    }

    public void OnJump(InputAction.CallbackContext context)// to call the function on the impute system 
    {
        Jump(); // to call the jump fuchtion 
    }

    public void OnShoot(InputAction.CallbackContext context)// to call the function on the impute system 
    {

        Shoot(); // to call the jumo function 

    }

    public void OnMM(InputAction.CallbackContext context)// to call the function on the impute system 
    {

        MainMenu();

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");

    }

    private void FixedUpdate()
    {
        Move(); // to call the move function 
        
    }

    private void LateUpdate()
    {
        Look(); //to call the look fuchtion 
    }
    private void Move() // the move fuchtion
    {

        // finding the target velocity
        Vector3 currentVolocity = rb.velocity;
        Vector3 targetVolcity = new Vector3(move.x, 0, move.y);
        targetVolcity *= speed;

        //align direction
        targetVolcity = transform.TransformDirection(targetVolcity);

        //calculate forces 
        Vector3 velocityChange = (targetVolcity - currentVolocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);
       
        
        //limit forces    
        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);

    }

    private void Look() // the look fuchtion 
    {
        transform.Rotate(Vector3.up * look.x * sensitivity); // the transform rotation is the vector 3 up time by the look.x time by the sensitivity 

        lookRotation += (-look.y * sensitivity); // look rotation is plus equal to mineeas look.y time sensitivity 
        lookRotation = Mathf.Clamp(lookRotation, -90, 90); // to clap hwo far the player can look 
        
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z); // t ocalcate the cam holder transform uler 

    }

    private void Jump() // the jump fuchtion 
    {
        Vector3 jumpForces = Vector3.zero; // the jumo foce is equal to vector 3 zero 

        if(isGrounded) // check if player is grounded 
        {
            jumpForces = Vector3.up * jumpForce; // jump fforces is vector 3 up time my the jump focus 
        }

        rb.AddForce(jumpForces, ForceMode.VelocityChange); // the rigibody add force is the jump focus , force mode velocity changes 

    }

    private void Shoot() // the soot fuchtion 
    {
        var bullet = Instantiate(myBullet, firePoint.position, firePoint.rotation); // to shoot the prefab bullet from fire point 
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed; // moving the bullet with the rigibody volicatity which is the fire point forward time by bullet speed 
       
    }

    public void SetGrounded(bool state) //set gorund fuchtion bool 
    {
        isGrounded = state; // to set is grounded equal state 


    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // to  hide the curser on the scream

    }

    

    private void OnCollisionEnter(Collision collision) // this fuchtion is for when player collides with another game obejc with colldier 
    {
        if (collision.gameObject.tag == "Door" && hasKey) // if collides with tag door and has key is true 
        {
          
            SceneManager.LoadScene("Main menu"); // lead the main manu sceam 

        }

        if (collision.gameObject.tag == "Key") // if collides with tag key 
        {
            hasKey = true; // set key true 


        }

    }

}
