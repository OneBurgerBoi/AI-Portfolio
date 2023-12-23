using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; // to use the unity editor 


[CustomEditor(typeof(FieldOfView))]   // a custom edit of the FOV scrpit 
public class FOVEditor :Editor // a editor classes scrpit 
{
    /// <summary>
    // this fuchion is to calcualte and be able to manuplate in the scene and to draw line of the radois and also when the  
    /// </summary>

    private void OnSceneGUI()
    {

        FieldOfView fieldOfView = (FieldOfView)target; // the FOV scrpit felid of view is equal to the target of the FOV script 
        Handles.color = Color.white; // draw handles colour is white 
        Handles.DrawWireArc(fieldOfView.transform.position, Vector3.up, Vector3.forward, 360, fieldOfView.radius); // to make the draw arc to see the Fild of view  and draws a radio around the player 

        Vector3 viewAngle01 = DirectionFromAngle(fieldOfView.transform.eulerAngles.y, -fieldOfView.angle / 2); // the view angle of 1 is  the field of view transform euler angle y and negative fild of view angle devied by 2

        Vector3 viewAngle02 = DirectionFromAngle(fieldOfView.transform.eulerAngles.y, fieldOfView.angle / 2); // the view angle of 2 isthe field of view transform euler anagle of y and the fild of view angle dveide by 2 

        Handles.color = Color.yellow; // the handles color is yellow 
        Handles.DrawLine(fieldOfView.transform.position, fieldOfView.transform.position + viewAngle01 * fieldOfView.radius); // the handles draw line is hte FOV transform position and the fov trasform. position add the view and angle 1 time by the fov radius 

        Handles.DrawLine(fieldOfView.transform.position, fieldOfView.transform.position + viewAngle02 * fieldOfView.radius);// the handles draw line is hte FOV transform position and the fov trasform. position add the view and angle 1 time by the fov radius 

        if (fieldOfView.seePlayer) // if FOV seePlayer true 
        {

            Handles.color = Color.green; // handle color is green
            Handles.DrawLine(fieldOfView.transform.position, fieldOfView.playerRef.transform.position); // and draw a line to the player 

            




        }

    }

    private Vector3 DirectionFromAngle(float eulery, float angleInDegrees) // the direction from angle method wth float euly and aganle in degrees 
    {

        angleInDegrees += eulery; // the angles in degrees plus equal eulery 

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad)); // return a new vctor 3 that caluate the angles  with math.

    }



}
