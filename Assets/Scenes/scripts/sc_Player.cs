using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Player : MonoBehaviour
{
    [Header("Main")]
    public List<ListOfSeeds> ListSeeds = new List<ListOfSeeds>();

    private sc_Manager_Game scriptManager;
    [Header("Audio")]
    public AudioSource audioData;
    public AudioClip drawerOpen;
    public float drawerOpenVolume = 0.5f;
    public AudioClip drawerClose;
    public float drawerCloseVolume = 0.5f;
    public AudioClip grabFruit;
    public float grabFruitVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = FindObjectOfType <sc_Manager_Game>();
        //Audio Code
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveSeed(int id)
    {
        ListSeeds[id].quantity --;
        
       if (ListSeeds[id].quantity <= 0)
        {
            if (ListSeeds[id].drawer != null)
            {
                ListSeeds[id].drawer.GetComponent<SpriteRenderer>().enabled = false;
                ListSeeds[id].drawer.GetComponent<BoxCollider2D>().enabled = false;
                //ListSeeds[id].drawerImage.SetActive(false);
                ListSeeds[id].drawer.transform.GetChild(0).gameObject.SetActive(false);

                //Audio Code
                audioData.clip = drawerClose;
                audioData.volume = drawerCloseVolume;
                audioData.Play();
            }
        }
    }

    public void AddSeed(int id)
    {
        ListSeeds[id].quantity ++;
       // scriptManager.CheckObjectifs();
        Debug.Log("le joueur recoit une graine");

        //Audio Code - condition Open one time
        if (ListSeeds[id].quantity == 1){
            audioData.clip = drawerOpen;
            audioData.volume = drawerOpenVolume;
            audioData.Play();
        }


        if (ListSeeds[id].quantity > 0)
        {
           ListSeeds[id].drawer.GetComponent<SpriteRenderer>().enabled = true;
           ListSeeds[id].drawer.GetComponent<BoxCollider2D>().enabled = true;
           //ListSeeds[id].drawerImage.SetActive(true);
           ListSeeds[id].drawer.transform.GetChild(0).gameObject.SetActive(true);
           //Audio Code
           ListSeeds[id].drawer.GetComponent<AudioSource>().clip = grabFruit;
           ListSeeds[id].drawer.GetComponent<AudioSource>().volume = grabFruitVolume;
           ListSeeds[id].drawer.GetComponent<AudioSource>().Play();
        }
    }
}

[System.Serializable]
 public class ListOfSeeds{
 
    public string name;
    public int quantity;
    public GameObject seedType;
    public GameObject drawer;

    public ListOfSeeds(string name, int quantity, GameObject seedType, GameObject drawer){
        this.name = name;
        this.quantity = quantity;
        this.seedType = seedType;
        this.drawer = drawer;
     }
 }
