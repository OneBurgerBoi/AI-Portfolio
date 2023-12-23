using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // use unity inbul scene management 

public class MenUController : MonoBehaviour
{
    

    public void StartGame() // the start game  fuchtion 
    {
        SceneManager.LoadScene("Game1"); // load the first level scene 
    }

    public void MTG() // the move to goal function 
    {
        SceneManager.LoadScene("Move To Goal"); // lode the scene move to goal 

    }

    public void PathFinding() // the pathfinding fuchtion 
    {
        SceneManager.LoadScene("Pathfinding"); // load the scene pathfinding 

    }

    public void RG() // robot guard fuchtion 
    {
        SceneManager.LoadScene("RobotGuard"); // load the robot guard scene 

    }

    public void FOv() // the field of view function 
    {
        SceneManager.LoadScene("FOV AI"); // load the field of view scene 

    }

    public void DragonAI() // the dragon AI fuchtion 
    {
        SceneManager.LoadScene("DragonBoss"); // load the dragon boss scene 

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");

    }

}
