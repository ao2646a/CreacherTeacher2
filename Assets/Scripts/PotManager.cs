using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotManager : MonoBehaviour
{
    public bool potFull = false;
    public bool potEmpty = true;

    [SerializeField] Renderer[] r = new Renderer[4];
    int i = 0; //current index of layer (0 to 3)

    Color[] c = new Color[4];

    bool mixed = false;

    // Start is called before the first frame update
    void Start()
    {
        r[0].enabled = false;
        r[1].enabled = false;
        r[2].enabled = false;
        r[3].enabled = false;

    }

    public void PourIn(Color pColor) { // pour in will only be called if pot is not full. 
        c[i] = pColor;
        r[i].material.color = c[i];
        r[i].enabled = true;
        i++;
        UpdateStatus();
    }

    public Color FillPotion() { // returns a color to be filled into the potion
        i--;
        Color pColor = c[i];
        r[i].enabled = false;
        UpdateStatus();
        return pColor;
    }

    public void Mix() {
        Debug.Log("Mixing colors..");
        Color result = new Color(0, 0, 0, 0);
        for (int colorIndex = 0; colorIndex <= i; colorIndex++) {
            Debug.Log("Mixing " + c[colorIndex]);
            result += c[colorIndex];
        }
        //result = result / (i + 1);
        for (int colorIndex = 0; colorIndex <= i; colorIndex++)
        {
            Debug.Log("updating..");
            c[colorIndex] = result;
            r[colorIndex].material.color = result;
        }
    }

    void UpdateStatus() {
        if (i > 3)
        {
            potFull = true;
            potEmpty = false;
        }
        else if (i <= 0)
        {
            potFull = false;
            potEmpty = true;
        }
        else {
            potFull = false;
            potEmpty = false;
        }
    }
}
