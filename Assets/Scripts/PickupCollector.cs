using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCollector : MonoBehaviour
{
    int empanadas = 0;
    public Text empanadaText;
    public GameObject eatingAnimation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectable") 
        {
            IncreaseEmpanadas();
            Instantiate(eatingAnimation, new Vector3(other.transform.position.x, other.transform.position.y, 0), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    void IncreaseEmpanadas() 
    {
        empanadas++;
        empanadaText.text = "Empanadas: " + empanadas.ToString();
    }
}
