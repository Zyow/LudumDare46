using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_WateringCan : MonoBehaviour
{

    private DragAndDrop dragScript;

    // Start is called before the first frame update
    void Start()
    {
        dragScript = GetComponent<DragAndDrop>();
    }

    private void OnMouseUp() {
        if ((dragScript.onThisGO != null) && (dragScript.onThisGO.tag == "Plant"))
        {
            AddWater();
        }
    }

    public void AddWater()
    {
        dragScript.audioData.Play();
        dragScript.onThisGO.GetComponent<sc_Plant>().AddWater();
    }
}
