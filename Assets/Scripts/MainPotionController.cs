using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPotionController : MonoBehaviour
{
    public static int colorIndex = 6;

    [SerializeField] public Color[] basePotion = new Color[colorIndex];
    public int currentIndex;

    Renderer r;
    [SerializeField] LibraryUIAppear lua; // the library UI appear - used to control achievement spell book

    // Start is called before the first frame update
    void Start()
    {
        //setting the renderer to control color of liquid
        r = transform.gameObject.GetComponent<Renderer>();

        currentIndex = 0;

        //setting color of object
        r.enabled = true;
        r.material.color = basePotion[currentIndex];


        //if object is placed on gold circle comapre with origina and call color comparator
        //if tagged with potion
    }

    public void ColorComparer(GameObject comparisonPotion)
    {
        PotionProperty pp = comparisonPotion.GetComponent<PotionProperty>();
        if (!pp.originalPotion)
        {
            if (pp.c == basePotion[currentIndex])
            {
                currentIndex++;
                r.material.color = basePotion[currentIndex];
                lua.NewPotionVisible();
            }
        }
    }

    /*
     * color comparisons
     * red: RGB: 255, 0 0 
     * blue: RGB: 0, 0, 255
     * yellow: 255, 255, 0
     * green: 0, 255, 0
     * purple: 255, 0, 255
     * orange: 255, 165, 0
     * */
}
