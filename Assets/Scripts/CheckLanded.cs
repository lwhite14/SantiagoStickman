using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanded : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovement.SetIsLanded(true);

        if (collision.tag == "MovingPlatform") 
        {
            playerMovement.SetPlayerParent(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.SetIsLanded(false);

        if (collision.tag == "MovingPlatform")
        {
            playerMovement.SetPlayerParent(null);
        }
    }
}
