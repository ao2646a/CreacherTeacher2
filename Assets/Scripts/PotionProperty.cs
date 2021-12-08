using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionProperty : MonoBehaviour
{
    [SerializeField] public Color c;
    [SerializeField] public bool potionFull;
    

    Renderer r;
    ColorManager cm;
    
    // Start is called before the first frame update
    void Start()
    {
        //setting the renderer to control color of liquid
        r = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        //setting color of object
        if (potionFull)
        {
            r.enabled = true;
            r.material.color = c;
        }
        else {
            r.enabled = false;
        } 
    }

    public void EmptyPotion() {
        potionFull = false;
        r.enabled = false;
    }

    public void FillPotion(Color pColor) {
        c = pColor;
        potionFull = true;
        r.enabled = true;
        r.material.color = c;
    }

}
