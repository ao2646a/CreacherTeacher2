using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPotionController : MonoBehaviour
{
    [SerializeField] public Color[] basePotion = new Color[6];
    public static int colorIndex;

    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        //setting the renderer to control color of liquid
        r = transform.gameObject.GetComponent<Renderer>();

        //setting color of object
        r.enabled = true;
        r.material.color = basePotion[colorIndex];


        //if object is placed on gold circle comapre with origina and call color comparator
        //if tagged with potion
    }

    public void ColorComparer(GameObject comparisonPotion)
    {
        if (comparisonPotion.GetComponent<Renderer>().material.color == transform.gameObject.GetComponent<Renderer>().material.color)
        {
            colorIndex++;
        }
    }

    /*
     * color comparisons
     * red: RGB: 255, 0 0 
     * blue: RGB: 0, 0, 255
     * yellow: 255, 255, 0
     * green: 0, 255, 0
     * purple: 255, 0, 255
     * orange: 255, 166, 0
     * */
}
