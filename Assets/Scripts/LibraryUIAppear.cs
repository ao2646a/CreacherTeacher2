using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryUIAppear : MonoBehaviour
{
    //[SerializeField] RawImage RawImagePotion;
    [SerializeField] RawImage [] rI = new RawImage [8]; 

    public int i = 0;
    public int j = 0;

    private void Start()
    {
        for (i = 0; i < 8; i++)
        {
            rI[i].enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            if (j < 8) {
                rI[j].enabled = true;
                j++;
            }
            
                
        }

    }








