using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController pC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pC.gameObject) return;

        pC.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pC.gameObject) return;

        pC.SetGrounded(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == pC.gameObject) return;

        pC.SetGrounded(true);
    }

}
