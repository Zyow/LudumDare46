using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Seed : MonoBehaviour
{
    [Header("Main")]
    public GameObject plantGO;
    public GameObject goDragScript;
    public sc_DragAndDrop_Seed dragScript;

    private void Start() {
        dragScript = goDragScript.GetComponent<sc_DragAndDrop_Seed>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Collision avec " + other.gameObject.name);
        
        if ((other.gameObject.tag == "Planter"))
        {
           // Debug.Log("Collision avec " + other.gameObject.name);

        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        dragScript.onThisGO = other.gameObject;
        dragScript.planterScript = other.GetComponent<sc_Planter>();

        if (other.gameObject.tag == "Planter")
            transform.rotation = Quaternion.Euler(0, 0, 35);
    }

    private void OnTriggerExit2D(Collider2D other) {
       // Debug.Log("Plus de collision avec " + other.gameObject.name);
        
        if (dragScript.onThisGO != null)
        {
            dragScript.onThisGO = null;
            dragScript.planterScript = null;
        }

        if (other.gameObject.tag == "Planter")
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
