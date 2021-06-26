using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnFinish : MonoBehaviour
{

    void SelfKill() 
    {
        Destroy(gameObject);
    }

}
