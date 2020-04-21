using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sc_SoundButton : MonoBehaviour
{
[Header("Main")]
public AudioSource audioData;

[Header("Menu/Button")]
public AudioClip startButton;
public float startButtonVolume;
public AudioClip exitButton;
public float exitButtonVolume;
public AudioClip creditButton;
public float creditButtonVolume;

[Header("Letter/Button")]
public AudioClip letterOpenButton;
public float letterOpenButtonVolume;
public AudioClip letterExitButton;
public float letterExitButtonVolume;

[Header("Book/Button")]
public AudioClip bookOpenButton;
public float bookOpenButtonVolume;
public AudioClip bookNextPrevButton;
public float bookNextPrevButtonVolume;
public AudioClip bookCloseButton;
public float bookCloseButtonVolume;
public AudioClip bookCreateButton;
public float bookCreateButtonVolume;

[Header("Next level")]
public AudioClip nextLevel;
public float nextLevelVolume;

    // Start is called before the first frame update
    private void Start()
    {
        //Audio Code
        audioData = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip value, float volumeValue){
        audioData.clip = value; 
        audioData.volume = volumeValue;
        audioData.Play();
    }

    public void PlayStartButtonSound(){
        PlaySound(startButton, startButtonVolume);
    }

    public void PlayExitButtonSound(){
        PlaySound(exitButton, exitButtonVolume);
    }

    public void PlayCreditButtonSound(){
        PlaySound(creditButton, creditButtonVolume);
    }

    public void PlayLetterExitButtonSound(){
        PlaySound(letterExitButton, letterExitButtonVolume);
    }
    public void PlayLetterOpenButtonSound(){
        PlaySound(letterOpenButton, letterOpenButtonVolume);
    }

    public void PlayBookOpenButtonSound(){
        PlaySound(bookOpenButton, bookOpenButtonVolume);
    }

    public void PlayBookNextPrevButtonSound(){
        PlaySound(bookNextPrevButton, bookNextPrevButtonVolume);
    }

    public void PlayBookCloseButtonSound(){
        PlaySound(bookCloseButton, bookCloseButtonVolume);
    }
    
    public void PlayBookCreateButtonSound(){
        PlaySound(bookCreateButton, bookCreateButtonVolume);
    }
    
}
