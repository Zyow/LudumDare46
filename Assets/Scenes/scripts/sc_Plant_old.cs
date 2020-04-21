using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Plant_old : MonoBehaviour
{
    //PLANT
    [Header("PLANT")]
    public int life = 3;
    public int level = 0;
    private int maxlife;
    public int tickBeforeLvlUp = 3;
    private int tickForLevelUp;
    public int howManyCheckForGoodCond;

    //DECAY
    [Header("DECAY"), Space(10)]
    public bool canDecay = true;
    public float decayEverySec;
    public bool firstDecay = true;
   
    //WATER
    [Header("WATER"), Space(10)]
    public bool needWater = false;
    public int water = 10;
    private int maxWater;
    public bool goodConditionWater = true;
    public int needForGoodConditionWater = 8;
    public int waterDecay = 1;

    //LOAM
    [Header("LOAM"), Space(10)]
    public bool needLoam = false;
    public bool isloam = false;
    public int loamQuality = 5;
    private int maxLoam;
    public int loamDecay = 1;
    

    void Start()
    {
        maxlife = life;
        maxWater = water;
        maxLoam = loamQuality;
        
        Debug.Log(gameObject.name + " vient de spawn");
        
        StartCoroutine("PlantDecay");
    }

    public void AddLife(int l)
    {
        life += l;
    }
    
    public void RemoveLife(int l)
    {
        life -= l;
    }

    public void AddWater(int w)
    {
        water += w;

        if (water > maxWater)
        {
            water = maxWater;
        }
    }

    public void Death()
    {
        Debug.Log(gameObject.name + "est morte");
        Destroy(gameObject);
    }

    IEnumerator PlantDecay()
    {
        while (canDecay)
        {
            if (!firstDecay)
            {
                if(needWater && water > 0)
                {
                    water -= waterDecay;
                    Debug.Log(gameObject.name + "A perdu de l'eau !");

                    if (water >= needForGoodConditionWater)
                        goodConditionWater = true;
                    else
                        goodConditionWater = false;
                        
                }

                if(needLoam)
                {
                    if(loamQuality > 0)
                    {
                        loamQuality -= loamDecay;
                        Debug.Log(gameObject.name + "A perdu de la qualité de terreau !");
                    }
                    else{
                        needLoam = true;
                    }
                }

                if(
                    needWater && water <= 0 || 
                    needLoam && loamQuality <= 0
                )
                {
                    RemoveLife(1);
                    Debug.Log(gameObject.name + "A perdu de la vie !");
                }

                

                if (life <= 0)
                {
                    Death();
                }

                if(needWater)
                {
                    if(goodConditionWater)
                    {
                        AddLife(1);
                    }
                }

                

            }
            else
            {
                firstDecay = false;
            }

            yield return new WaitForSeconds(decayEverySec);
        }
            
    }
}
