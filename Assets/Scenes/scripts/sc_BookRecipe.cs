using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sc_BookRecipe: MonoBehaviour
{
    public string recipeName;
    public int seedRecipeId;
    public TextMeshProUGUI textTitle;

    public List<needOfRecipe> Recipe = new List<needOfRecipe>();

    public int checkNeed = 0;

    private sc_Player scriptPlayer;  
    private bool firstTime = true;

    void Start()
    {
        scriptPlayer = FindObjectOfType<sc_Player>();
        updateRecipe();
    }

    private void OnEnable() {
        if (!firstTime)
            updateRecipe();
    }

    private void Update() {
        updateRecipe();    
    }

    void updateRecipe()
    {
        if (firstTime)
        {
            textTitle.text = recipeName;
            firstTime = false;
        }

        for(int i=0; i < Recipe.Count; i++)
        {
            Recipe[i].textSeedNeeded.text = Recipe[i].NameSeedNeeded.ToString();
            Recipe[i].textNeeded.text = Recipe[i].quantityNeeded.ToString();
            Recipe[i].textHas.text = scriptPlayer.ListSeeds[Recipe[i].IdPlant].quantity.ToString();
            
            if (scriptPlayer.ListSeeds[Recipe[i].IdPlant].quantity >= Recipe[i].quantityNeeded)
            {
                Recipe[i].has = true;
            }
        } 
    }

    public void CreateSeed()
    {
        checkNeed = 0;

        for(int i=0; i < Recipe.Count; i++)
        {
            if (Recipe[i].has)
            {
                checkNeed ++;
            }
        }

        if (checkNeed == Recipe.Count )
        {

            for(int i=0; i < Recipe.Count; i++)
            {
                if(scriptPlayer.ListSeeds[Recipe[i].IdPlant].quantity >= 0 )
                {
                    scriptPlayer.ListSeeds[Recipe[i].IdPlant].quantity -=  Recipe[i].quantityNeeded;
                }
                else
                {
                    scriptPlayer.ListSeeds[Recipe[i].IdPlant].quantity = 0;
                }

                Recipe[i].has = false;
            }

            Debug.Log("CREATE SEED ID " + seedRecipeId );
            scriptPlayer.AddSeed(seedRecipeId);

            updateRecipe();
        }
    }

}

[System.Serializable]
 public class needOfRecipe{
    public string NameSeedNeeded;
    public TextMeshProUGUI textSeedNeeded;
    public int IdPlant;
    public TextMeshProUGUI textHas;
    public int quantityNeeded;
    public TextMeshProUGUI textNeeded;
    public bool has;


    public needOfRecipe(
        string NameSeedNeeded,
        TextMeshProUGUI textSeedNeeded,
        int IdPlant, 
        int quantityNeeded, 
        TextMeshProUGUI textHas, 
        bool has, 
        TextMeshProUGUI textNeeded)
        {
        this.NameSeedNeeded = NameSeedNeeded;
        this.textSeedNeeded = textSeedNeeded;
        this.IdPlant = IdPlant;
        this.textHas = textHas;
        this.quantityNeeded = quantityNeeded;
        this.textNeeded = textNeeded;
        this.has = has;

     }
 }
