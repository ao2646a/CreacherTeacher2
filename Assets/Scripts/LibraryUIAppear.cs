using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LibraryUIAppear : MonoBehaviour
{
    //[SerializeField] RawImage RawImagePotion;
    [SerializeField] RawImage [] rI = new RawImage [6]; 

    public int i = 0;
    public int j = 0;
    private int counter = MainPotionController.colorIndex;

    private void Start()
    {
        for (i = 0; i < 6; i++)
        {
            rI[i].enabled = false;
        }
    }

    public void Update()
    {
        if (counter < MainPotionController.colorIndex)
        {
            if (j < 6)
            {
                rI[counter].enabled = true;
                j++;
            }


            if (j == 6)
            {
                SceneManager.LoadScene("Celebration");
            }
        }

     }
    

    }










