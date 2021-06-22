using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanded : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovement.SetIsLanded(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.SetIsLanded(false);
    }
}
