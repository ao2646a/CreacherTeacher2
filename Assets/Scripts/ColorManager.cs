using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // v for prototyping
    public int index = 0;
    public  Color a;
    public Color b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Once 2 colors are selected, color of test screen changes to that color.
        

    }

    // Method to combine colors and make a new color
    public Color Mix(Color a, Color b){
        Color result = new Color(0, 0, 0, 0);
        Debug.Log("mixing "+ a +" and "+ b);
        result += a;
        result += b;
        result /= 2;
        Debug.Log(result);
        return result;
    }
}
