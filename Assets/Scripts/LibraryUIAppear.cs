using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryUIAppear : MonoBehaviour
{
    [SerializeField] RawImage RawImagePotion;

    private void Start()
    {
        RawImagePotion.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RawImagePotion.enabled = true;
        }

    }




}






