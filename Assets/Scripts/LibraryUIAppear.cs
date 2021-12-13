using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LibraryUIAppear : MonoBehaviour
{

    private int counterMax = MainPotionController.colorIndex;

    //[SerializeField] RawImage RawImagePotion;
    [SerializeField] RawImage[] rI;


    int i = 0;
    int j = 0;
    //private int counter = MainPotionController.colorIndex;

    private void Start()
    {
        // first setting all potion icons to nonvisible
        for (i = 0; i < counterMax; i++)
        {
            rI[i].enabled = false;
        }

    }

    public void NewPotionVisible(){
        if (j < counterMax)
        {
            rI[j].enabled = true;
            j++;
            Debug.Log("hit" + j);
        }
        else if (j == counterMax)
        {
            Debug.Log(j);
            SceneManager.LoadScene("Celebration");
        }
    }
    

    }










