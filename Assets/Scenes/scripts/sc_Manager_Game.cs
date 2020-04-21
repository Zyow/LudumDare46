using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_Manager_Game : MonoBehaviour
{
    
    //public GameObject[] letters;

    [Header("Menu"), Space(10)]
    public GameObject menuGO;
    public bool firstLaunch = true;

    [Header("Letters"), Space(10)]
     public List<GameObject> letters = new List<GameObject>();

    [Header("Musics"), Space(10)]
    public AudioClip musicIntro;
    public AudioClip musicGame;    
    private AudioSource audiodata;
    public GameObject ManagerAudio;
    private sc_SoundButton scSoundButton;

    [Header("Level"), Space(10)]
    public int actualLevel = 0;
    public List<int> IDPlantVictoryConditions = new List<int>();
    public List<GameObject> listeMeuble = new List<GameObject>();
    public List<sc_Planter> Pots = new List<sc_Planter>();
    private sc_Player scriptPlayer;
    private sc_Book scriptBook;

    private bool pause = false;
    

    // Start is called before the first frame update
    void Start()
    {
        audiodata = GetComponent<AudioSource>();
        scriptPlayer = FindObjectOfType<sc_Player>();
        scriptBook = FindObjectOfType<sc_Book>();
        //scriptManager = FindObjectOfType <sc_Manager_Game>();

        //Letters
        DisableLetters();

        audiodata.clip = musicIntro;
        PlayMusic();        

        if(ManagerAudio != null){
            scSoundButton = GetComponent<sc_SoundButton>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.P)) 
        {
            if (!pause) 
            {
                Time.timeScale = 0;
                pause = true;
                Debug.Log("Pause");
            }
            else if (pause) 
            {
                Time.timeScale = 1;  
                pause = false;
                Debug.Log("UNPause");
            }
        } 

        if (Input.GetKeyDown("r")) { //If you press R
            RestartGame();
        }

        if(Input.GetKeyDown (KeyCode.Escape)) 
        {
            ExitGame();
        } 

    }

    /*public void CheckObjectifs()
    {
        if(scriptPlayer.ListSeeds[IDPlantVictoryConditions[actualLevel]].quantity > 0)
        {
            Debug.Log("NEXT LEVEL");
            actualLevel ++;
            ShowLetter();
            scriptBook.disableBook();
        }
    }*/

    public void WinLevel()
    {
        Debug.Log("NEXT LEVEL");
        actualLevel ++;
        ShowLetter();
        scriptBook.disableBook();
        changeMeuble();

        for(int i=0; i < Pots.Count; i++)
        {
            GameObject g = Pots[i].plantInPot;
            Destroy(g);
        }
        //Audio Code Next Level
        scSoundButton.audioData.clip = scSoundButton.nextLevel; 
        scSoundButton.audioData.volume = scSoundButton.nextLevelVolume;
        scSoundButton.audioData.Play();
    }

    void changeMeuble()
    {
        for(int i=0; i < listeMeuble.Count; i++)
        {
            listeMeuble[i].SetActive(false);
        }

        listeMeuble[actualLevel].SetActive(true);
    }

    public void ShowLetter()
    {
        DisableLetters();
        Debug.Log("letter ouverte n° " + actualLevel);
        letters[actualLevel].SetActive(true);

        if(actualLevel == 0 || actualLevel == 1){
            audiodata.pitch = 1.0f;
        }
        if(actualLevel == 2)
            audiodata.pitch = 0.5f;
        if(actualLevel == 3)
            audiodata.pitch = 0.3f;    
    }

    public void CloseLetter()
    {
        letters[actualLevel].SetActive(false);

        //Audio Code
        audiodata.pitch = 1.0f;
    }

    void DisableLetters()
    {
        for(int i=0; i < letters.Count; i++)
        {
            letters[i].SetActive(false);
        }
    }

    public void LaunchTheGame()
    {
        menuGO.SetActive(false);
        if(firstLaunch)
        {
            ShowLetter();
            audiodata.clip = musicGame;
            PlayMusic();
        }
    }

    void PlayMusic()
    {
        audiodata.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); //Load scene called Game
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

