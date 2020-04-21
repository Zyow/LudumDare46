using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Planter : MonoBehaviour
{
    public GameObject plantInPot;
    //Audio Code
    public AudioSource audioData;

     private void Start() {
        //Audio Code
        audioData = GetComponent<AudioSource>();
    }

    public void ChangeGameobject(GameObject go)
    {
        plantInPot = go;
        audioData.Play();
    }

    public void DeletePlant()
    {
        if (plantInPot != null)
        {
            Debug.Log(plantInPot + " détruite!");
            Destroy(plantInPot);
            //plantInPot = null;
        }
    }

   /* private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision avec " + other.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Plus de collision avec " + other.gameObject.name);
    }
    */
}
