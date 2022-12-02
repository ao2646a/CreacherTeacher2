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

    public UnityEngine.UI.Text text;

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
        text.enabled = true;
        text.text = "Reproduce the potion next to the golden plate! \n Start by grabbing the potion in red.";
    }

    void Update() {
        if (!partOneDone)
        {
            TutorialPartOne();
        }
        else if (!partTwoDone)
        {
            if (Input.GetMouseButtonDown(0)) {
                text.enabled = false;
            }
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
                    partOneDone = true;
                    text.text = "You did it! Now, keep going and learn all about \n" +
                    "color mixing! Remember, some quest might involve some potion mixing.";

            }
        }
        else if (emptyPotionFilled)
        {
            potr.material.color = potc;
            comparePlater.material.color = Color.red;
            if (mpc.currentIndex == 1)
            {
                compared = true;
                text.text = "Yaaaay! We did it!\n" +
                    "Click the red trash can and empty our bottle, so we can be prepared for our next quest displayed in the bottle next to the golden plate!";
            }
        }
        else if (emptyPotionClicked)
        {
            emptyPotionr.material.color = emptyPotionc;
            potr.material.color = Color.red;
            if (pm.potEmpty && fpc.hasPotion && fpc.currentPotion.transform.GetChild(1).gameObject == emptyPotion)
            {
                emptyPotionFilled = true;
                text.text = "We have our potion!\n" +
                    "Now put the potion onto the golden plate to test whether it is the color we want.";
            }
        }
        else if (potFilled)
        {
            potr.material.color = potc;
            emptyPotionr.material.color = Color.red;
            if (fpc.hasPotion && fpc.currentPotion.transform.GetChild(1).gameObject == emptyPotion)
            {
                emptyPotionClicked = true;
                text.text = "Nicely done! Now let's scoop the potion from the pot!";
            }
        }
        else if (redPotionClicked)
        {
            redPotionr.material.color = redPotionc;
            potr.material.color = Color.red;
            if (!pm.potEmpty)
            {
                potFilled = true;
                text.text = "Since our designated potion color is red, and the potion " +
                    "in pot is already red, we can simply scoop " +
                    "it out with an empty bottle. Grab the empty bottle!\n" +
                    "(But don't forget to put down your current potion first)";
            }
        }
        else
        {
            redPotionr.material.color = Color.red;
            // updating the booleans.
            if (fpc.hasPotion && fpc.currentPotion.transform.GetChild(1).gameObject == redPotion)
            {
                redPotionClicked = true;
                text.text = "Next, pour the potion into the mixing pot.";
            }
        }

        
    }
    // direct the player to click the mixing stick
    void TutorialPartTwo()
    {
        if (pm.i >= 2 && pm.mixed) {
            mixingStickr.material.color = mixingStickc;
            partTwoDone = true;
            text.enabled = false;
        } else if (pm.i >= 2)
        {
            if (pm.c[0] != pm.c[2])
            {
                mixingStickr.material.color = Color.red;
                text.enabled = true;
                text.text = "Let's click the mixing stick to mix up the colors!";
            }
        }
    }

}
