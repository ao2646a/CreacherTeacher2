using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionProperty : MonoBehaviour
{
    [SerializeField] Color c;

    Renderer r;

    ColorManager cm;
    

    // Start is called before the first frame update
    void Start()
    {
        //setting color of object
        cm = GameObject.Find("TestScreen").GetComponent<ColorManager>();
        r = GetComponent<Renderer>();
        r.material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        //once selected, +1, when 2 selected, update color of test screen.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Potion")
                {
                    if (cm.index == 0)
                    {
                        cm.index = 1;
                        cm.a = c;
                    }
                    else {
                        cm.index = 0;
                        //ColorManager.b = c;

                        Renderer testRenderer = GameObject.Find("TestScreen").GetComponent<Renderer>();
                        Color result = cm.Mix(cm.a, c);
                        Debug.Log("result in potion:" + result);
                        testRenderer.material.color = result;
                    }
                }
            }
        }


        
    }

}
