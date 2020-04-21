using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Plant: MonoBehaviour
{

    public int IDPlant;
    public bool canFinishLevel = false;

    private sc_Player scriptPlayer;
    private sc_Manager_Game scriptManager;

    //LIFE
    [Header("LIFE"), Space(10)]
    public float plantLife = 60;
    public bool isDead = false;
    public float needForGoodCond = 40;
    public float needForSadCond = 15;
    public int plantStatutCond = 2; //0 > Dead, 1 > Sad, 2 > Normal, 3 > Good
    private float plantLifeMax;

    //LEVEL
    [Header("LEVEL"), Space(10)]
    public int plantLevel = 0; //0 > Sprout, 1 > Normal, 2 > Bloom
    public float timeForLvlUp = 5;
    public bool canTryToLvlUp;
    public float timerCount;
    public bool canBeGrab;
    public GameObject seedGO;

    //SPRITES
    [Header("SPRITES"), Space(10)]
    public List<AllPlantSsprites> plantSprites = new List<AllPlantSsprites>();
    //0 > Water, 1 > Loam
    //public Sprite[] lvlSpritePlantNormal;
    //public Sprite[] lvlSpritePlantSad;
    private SpriteRenderer spritePlant;

    //TIMER
    [Header("TIMER")]
    public float decayEverySeconds;
    public bool canDecay;

    //public bool canGainLife = false;

    public int checkNeed = 0;
    public int checkIsOk = 0;

    //NEEDED
    [Header("Needed"), Space(10)]
    public List<AllPlantNeeds> plantNeeds = new List<AllPlantNeeds>();

     [Header("Particles"), Space(10)]
    public GameObject particlesGood;
    public GameObject particlesHeal;

    
    void Start()
    {
        scriptPlayer = FindObjectOfType<sc_Player>() ;
        scriptManager = FindObjectOfType <sc_Manager_Game>();
        spritePlant = GetComponent<SpriteRenderer>();
        plantLifeMax = plantLife;
        timerCount = timeForLvlUp;

        ChangeSprite();
        
        StartCoroutine("PlantTimer");
    }
    
    public void AddWater()
    {
        //if (needWater)
        plantNeeds[0].has = true;
    }

    public void AddLoam()
    {
        plantNeeds[1].has = true;
    }

    public void AddGoatsBlood()
    {
        plantNeeds[2].has = true;
    }
    
    public void AddVirginsTears()
    {
        plantNeeds[3].has = true;
    }
    
    public void AddGraveyardDirt()
    {
        plantNeeds[4].has = true;
    }

    public void AddGoupilsHairs()
    {
        plantNeeds[5].has = true;
    }

    public void AddToadsDrool()
    {
        plantNeeds[6].has = true;
    }

    public void AddEyeOfANewt()
    {
        plantNeeds[7].has = true;
    }

    public void AddPowderOfPerlimpinpin()
    {
        plantNeeds[8].has = true;
    }

    public void AddCoffeeGrounds()
    {
        plantNeeds[9].has = true;
    }

    public void AddNaturalFertilizer()
    {
        plantNeeds[10].has = true;
    }

    public void AddUnicornSkin()
    {
        plantNeeds[11].has = true;
    }

    public void AddLife()
    {
        plantLife = plantLifeMax;
    }
    
    public void RemoveLife(int l)
    {
        plantLife -= l;
    }
    
    private void CheckLife()
    {
        if(plantLife > needForGoodCond) // GOOD CONDITION
        {
            plantStatutCond = 3;
            canTryToLvlUp = true;
            particlesGood.SetActive(true);
        }
        else if (plantLife < needForSadCond && plantLife > 0) // SAD CONDITION
        {
            if( plantLevel == 2)
            {
                LevelDown();
            }

            particlesGood.SetActive(false);    
            plantStatutCond = 1;
            ResetTimerLvlUp();
        }
        else if (plantLife <= 0) // DEAD CONDITION
        {
            plantStatutCond = 0;
            ResetTimerLvlUp();
            isDead = true;
            canDecay = false;
            particlesGood.SetActive(false);    

        }
        else //NORMAL CONDITION
        {
            plantStatutCond = 2;
            ResetTimerLvlUp();
            particlesGood.SetActive(false);    
        }

        if (plantLevel == 2)
        {
            canBeGrab = true;
        }
        else
        {
            canBeGrab = false;
        }
    }

    private void ResetTimerLvlUp()
    {
        canTryToLvlUp = false;
        timerCount = timeForLvlUp;
    }

    private void TimerForLevel()
    {
        if (canTryToLvlUp)
        {
            timerCount --;
            
            if (timerCount <= 0)
                LevelUp();
        
        }
    }
    
    private void LevelUp()
    {
        if (plantLevel < 2)
        {
            plantLevel ++;
            canTryToLvlUp = false;
            timerCount = timeForLvlUp;
        }
    }

    private void LevelDown()
    {
        plantLevel --;
        canBeGrab = false;
    }

    private void OnMouseDown() {
        if (canBeGrab)
        {
            if(canFinishLevel)
            {
                scriptManager.WinLevel();
                Destroy(this.gameObject);
            }
            else
            {
                scriptPlayer.AddSeed(IDPlant);

                Debug.Log("Graines ramassées");
                LevelDown();
            }
        }
    }


    private void ChangeSprite()
    {
        if(plantLevel == 0 && plantSprites[plantStatutCond].lvl0)
            spritePlant.sprite = plantSprites[plantStatutCond].lvl0;
        else if(plantLevel == 1 && plantSprites[plantStatutCond].lvl1)
            spritePlant.sprite = plantSprites[plantStatutCond].lvl1;
        else if(plantLevel == 2 && plantSprites[plantStatutCond].lvl2)
            spritePlant.sprite = plantSprites[plantStatutCond].lvl2;
    }

    IEnumerator PlantTimer()
    {
        while (canDecay)
        {   
            checkIsOk = 0;
            checkNeed = 0;

            //hasWater = false;

        for(int i=0; i < plantNeeds.Count; i++)
        {
            if(plantNeeds[i].need)
            {
                checkNeed ++;

                 if (plantNeeds[i].has == plantNeeds[i].need)
                {
                    //Debug.Log("isOK");
                    plantNeeds[i].isOk = true;
                    plantNeeds[i].needCheck = true;
                }
                else
                {
                    //Debug.Log("NotOK");
                    plantNeeds[i].isOk = false;
                    plantNeeds[i].needCheck = true;
                }
            }
            else
            {
                //Debug.Log("PAS DE NEED");
                plantNeeds[i].needCheck = false;
            }
        }

        for(int i=0; i < plantNeeds.Count; i++)
        {
            if (plantNeeds[i].needCheck)
            {
                if (!plantNeeds[i].isOk)
                {
                    //Debug.Log("DECAY");
                }
                else
                {
                    checkIsOk ++;
                    //Debug.Log("GAGNE DE LA VIE");
                }
            }
        }

        if (checkNeed == checkIsOk)
        {
            //canGainLife = true;
            //Addlife
            AddLife();
            particlesHeal.GetComponent<ParticleSystem>().Play();

            for(int i=0; i < plantNeeds.Count; i++)
            {
                plantNeeds[i].has = false;
                plantNeeds[i].isOk = false;
                plantNeeds[i].needCheck = false;
            }
        }
        else
        {
            //Removelife
            RemoveLife(1);
            //canGainLife = false;
        }
            
            CheckLife();
            TimerForLevel();
            ChangeSprite();

            //Debug.Log("timer");
            yield return new WaitForSeconds(decayEverySeconds);
        }
    }
}

[System.Serializable]
 public class AllPlantNeeds{
 
     public string name;
     public bool need;
     public bool has;
     public bool needCheck;
     public bool isOk;
 
     public AllPlantNeeds(string name, bool need, bool has, bool needCheck, bool isOk){
         this.name = name;
         this.need = need;
         this.has = has;
         this.needCheck = needCheck;
         this.isOk = isOk;
     }
 }

 [System.Serializable]
 public class AllPlantSsprites{
 
    public string name;
    public Sprite lvl0;
    public Sprite lvl1;
    public Sprite lvl2;

     public AllPlantSsprites(string name, Sprite lvl0, Sprite lvl1, Sprite lvl2){
         this.name = name;
         this.lvl0 = lvl0;
         this.lvl1 = lvl1;
         this.lvl2 = lvl2;
     }
 }