using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject liquid;
    public GameObject liquidMesh;

    private int movementSpeed = 60;
    private int roationSpeed = 15;

    private int diff = 25;

    
    void Update()
    {
        Slosh();
        //slowly roate the object over time
        liquidMesh.transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime, Space.Self);
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
