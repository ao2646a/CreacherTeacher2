using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // first, obtainning all objects needed for tutorial
    [SerializeField] GameObject redPotion;
    [SerializeField] GameObject emptyPotion;
    [SerializeField] GameObject pot;
    [SerializeField] GameObject mixingStick;
    [SerializeField] GameObject comparePlate;
    [SerializeField] GameObject trash;

    Color redPotionc;
    Color emptyPotionc;
    Color potc;
    Color mixingStickc;
    Color comparePlatec;
    Color trashc;

    Renderer redPotionr;
    Renderer emptyPotionr;
    Renderer potr;
    Renderer mixingStickr;
    Renderer comparePlater;
    Renderer trashr;

    // used to track progress of tutorial
    bool redPotionClicked = false;
    bool potFilled = false;
    bool emptyPotionClicked = false;
    bool emptyPotionFilled = false;
    bool compared = false;
    bool partOneDone = false;
    //bool mixingStickClicked = false;
    bool partTwoDone = false;

    [SerializeField] MainPotionController mpc;
    [SerializeField] PotManager pm;
    [SerializeField] FPControl fpc;

    void Start() {
        redPotionr = redPotion.GetComponent<Renderer>();
        emptyPotionr = emptyPotion.GetComponent<Renderer>();
        potr = pot.GetComponent<Renderer>();
        mixingStickr = mixingStick.GetComponent<Renderer>();
        comparePlater = comparePlate.GetComponent<Renderer>();
        trashr = trash.GetComponent<Renderer>();

        redPotionc = redPotionr.material.color;
        emptyPotionc = emptyPotionr.material.color;
        potc = potr.material.color;
        mixingStickc = mixingStickr.material.color;
        comparePlatec = comparePlater.material.color;
        trashc = trashr.material.color;
    }

    void Update() {
        if (!partOneDone)
        {
            TutorialPartOne();
        }
        else if (!partTwoDone)
        {
            TutorialPartTwo();
        }
        else {
            GetComponent<TutorialManager>().enabled = false; //  tutorial done
        }


        

    }
    // first, direct the player to click the red potion, put in pot, fill in empty potion, and put on compare plate
    void TutorialPartOne() {
        if (compared) {
            comparePlater.material.color = comparePlatec;
            trashr.material.color = Color.red;
            if ((fpc.currentPotion.transform.GetChild(1).gameObject == emptyPotion)&&(!fpc.currentPotion.GetComponent<PotionProperty>().potionFull)) 
            {
                    trashr.material.color = trashc;
                    partOneDone = true; }
        }
        else if (emptyPotionFilled)
        {
            potr.material.color = potc;
            comparePlater.material.color = Color.red;
            if (mpc.currentIndex == 1)
            {
                compared = true;
            }
        }
        else if (emptyPotionClicked)
        {
            emptyPotionr.material.color = emptyPotionc;
            potr.material.color = Color.red;
            if (pm.potEmpty && fpc.hasPotion && fpc.currentPotion.transform.GetChild(1).gameObject == emptyPotion)
            {
                emptyPotionFilled = true;
            }
        }
        else if (potFilled)
        {
            potr.material.color = potc;
            emptyPotionr.material.color = Color.red;
            if (fpc.hasPotion && fpc.currentPotion.transform.GetChild(1).gameObject == emptyPotion)
            {
                emptyPotionClicked = true;
            }
        }
        else if (redPotionClicked)
        {
            redPotionr.material.color = redPotionc;
            potr.material.color = Color.red;
            if (!pm.potEmpty)
            {
                potFilled = true;
            }
        }
        else
        {
            redPotionr.material.color = Color.red;
            // updating the booleans.
            if (fpc.hasPotion && fpc.currentPotion.transform.GetChild(1).gameObject == redPotion)
            {
                redPotionClicked = true;
            }
        }

        
    }
    // direct the player to click the mixing stick
    void TutorialPartTwo()
    {
        if (pm.i >= 2 && pm.mixed) {
            mixingStickr.material.color = mixingStickc;
            partTwoDone = true;
        } else if (pm.i >= 2)
        {
            if (pm.c[0] != pm.c[2])
            {
                mixingStickr.material.color = Color.red;
            }
        }
    }
}
