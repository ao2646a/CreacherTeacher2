using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryUIAppear : MonoBehaviour
{
    //[SerializeField] RawImage RawImagePotion;
    [SerializeField] RawImage [] rI = new RawImage [6]; 

    public int i = 0;
    public int j = 0;

    private void Start()
    {
        for (i = 0; i < 6; i++)
        {
            rI[i].enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            if (j < 6) {
                rI[j].enabled = true;
                j++;
            }
            
                
        }

    }








