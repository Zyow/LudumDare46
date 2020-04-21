using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_DragAndDrop_Seed : MonoBehaviour
{
Rigidbody2D rb;

    public bool isDragging;
    public bool isCollided = false;

    public GameObject seedGO;
    public GameObject seedCreated;

    public bool onAObject = false;
    public GameObject onThisGO = null;
    public sc_Planter planterScript;

    private Vector2 initPosition;
    private float deltaX, deltaY;

    public sc_Player scriptPlayer;
    public int IDPlant;
    //Audio Code
    [Header("Audio")]
    public AudioSource audioData;
    public AudioClip grabSeed;
    public float grabSeedVolume = 0.5f;

    private void Start() {
        initPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //Audio Code
        audioData = GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        isDragging = true;
        
        seedCreated = Instantiate(scriptPlayer.ListSeeds[IDPlant].seedType);
        scriptPlayer.RemoveSeed(IDPlant);

        seedCreated.GetComponent<sc_Seed>().goDragScript = this.gameObject; 
        //seedCreate.GetComponent<sc_Seed>().plantGO = scriptPlayer.ListSeeds[IDPlant].seedType; 

        //Audio Code
        audioData.clip = grabSeed;
        audioData.volume = grabSeedVolume;
        audioData.Play();
    }

    private void OnMouseDrag() {
          if( isDragging )
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            seedCreated.GetComponent<Rigidbody2D>().MovePosition(mousePosition);
        }
    }

    private void OnMouseUp() {
        isDragging = false;

        if(onThisGO)
        {
            planterScript.DeletePlant();
            GameObject go = Instantiate(seedCreated.GetComponent<sc_Seed>().plantGO, onThisGO.transform.GetChild(0).transform.position, Quaternion.identity);
            planterScript.ChangeGameobject(go);
            Destroy(seedCreated);
        }
        else
        {
            scriptPlayer.AddSeed(IDPlant);
            Destroy(seedCreated);
        }


        /*if ((onThisGO != null) && (onThisGO.tag == "Planter"))
        {
           if (planterScript.GetComponent<sc_Planter>() && planterScript.GetComponent<sc_Planter>().plantInPot != null )
            {
                Debug.Log(" plante supprimé!");
                planterScript.DeletePlant();
                Destroy(seedCreate);

            }

            GameObject go = Instantiate(seedCreate.GetComponent<sc_Seed>().plantGO, onThisGO.transform.GetChild(0).transform.position, Quaternion.identity);
            
            Debug.Log(go + " créé!");
            
            if (planterScript != null)
            {
                Debug.Log(go + " Modifié!");
                planterScript.ChangeGameobject(go);
                Destroy(seedCreate);
            }
        }
        else
        {
            scriptPlayer.AddSeed(IDPlant);
            Destroy(seedCreate);
            
        }*/

    }

    private void RestartPosition()
    {
        transform.position = initPosition;
    }

    public void OnObject(){
        onAObject = true;
    }

    public void ExitObject(){
        onAObject = false;
    }
}