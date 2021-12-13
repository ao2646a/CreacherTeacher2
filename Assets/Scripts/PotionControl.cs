using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionControl : MonoBehaviour
{
    public GameObject liquid;
    //public GameObject liquidMesh;

    private int movementSpeed = 60;
    private int roationSpeed = 15;

    Vector3 position; // orginal position of potion

    private int diff = 25;

    bool isHeld = false;


    void Start()
    {
        position = transform.position;
    }
        void Update()
    {
        Slosh();

        //slowly roate the object over time
        //liquidMesh.transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime, Space.Self);
    }

    public void Snapback() {
        transform.position = position;
        // refill if one of the original
        PotionProperty pp = GetComponent<PotionProperty>();
        if (pp.originalPotion)
        {
            pp.FillPotion(pp.c);
        }
    }

    private void Slosh()
    {
        //take the inverse roattion of the mug but stay within established values

        Quaternion inverseRoatation = Quaternion.Inverse(transform.localRotation);

        //where the roation is going to
        Vector3 finalRotation = Quaternion.RotateTowards(liquid.transform.localRotation, inverseRoatation, movementSpeed * Time.deltaTime).eulerAngles;

        //limit on x and z axis
        finalRotation.x = LimitRoatationValue(finalRotation.x, diff);
        finalRotation.z = LimitRoatationValue(finalRotation.z, diff);

        liquid.transform.localEulerAngles = finalRotation;


    }

    private float LimitRoatationValue(float value, float difference)
    {
        float returnVal = 0.0f;

        if (value > 180)
        {
            //then limit movement between 335 and 60
            returnVal = Mathf.Clamp(value, 360 - difference, 360);
        }
        else
        {
            // if less than 180 clamp between 0 and 25
            returnVal = Mathf.Clamp(value, 0, difference);
        }

        return returnVal;
    }
}
