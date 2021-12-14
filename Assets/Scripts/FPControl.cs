using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPControl : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float walkSpeed = 5f;

    [SerializeField] bool cursorLocked = true;
    [SerializeField] Texture2D cursorTexture;

    [SerializeField] LayerMask PlayerLayerMask;

    Vector3 gravity = Vector3.down;
    bool isGrounded = true;

    public bool hasPotion = false; // boolean used to determine whether player is holding a potion 
    //bool hasPot = false; // boolean used to determine whether player is holding the pot
    [SerializeField] GameObject container;
    public GameObject currentPotion;

    float cameraPitch = 0.0f;
    UnityEngine.CharacterController controller = null;

    // used to pick up potion
    
    PotionProperty p; // for when a potion is grabbed by player

    // getting a reference to the mixing pot
    [SerializeField] GameObject mixingPot;
    PotManager pm;

    [SerializeField] GameObject mainPotionLiquid;
    MainPotionController mpc;

    // Start is called before the first frame update
    void Start()
    {
        //initalizing the character controller
        controller = GetComponent<UnityEngine.CharacterController>();

        //keeping the cursor in place
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }

        //grabbing the pot manager script reference
        pm = mixingPot.GetComponent<PotManager>();

        // grabbing the main potion controller script reference
        mpc = mainPotionLiquid.GetComponent<MainPotionController>();

    }

    // Update is called once per frame
    void Update()
    {
        updateMouseLook();
        updatePlayerMovement();
        updateClick();
        // exert down force as gravity
        Gravity();
    }

    void Gravity() {

        RaycastHit hitInfo;// = new RaycastHit();
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //bool hit = 

        if (Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }
        
        if (!isGrounded) {
            transform.position += gravity*0.1f;
        }
    }

    void updateMouseLook()
    {

        Vector2 mouseChange = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //calculating y change of camera, but keeping it within a +-90 degree range
        cameraPitch -= mouseChange.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        // rotating the camera upon mouse movement
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseChange.x * mouseSensitivity);

    }

    void updatePlayerMovement()
    {

        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputDir.Normalize();

        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;

        controller.Move(velocity * Time.deltaTime);
    }

    void updateClick()
    {
        // once mouse clocked, determine the situation and react accordingly
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo;// = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(ray, out hitInfo, 100.0f, PlayerLayerMask);

            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);

                // if a potion is selected
                if (hitInfo.transform.gameObject.tag == "Potion")
                {
                    // if already holding a potion, do nothing
                    // if hands empty, grab potion
                    if (!hasPotion) // && !hasPot)
                    {
                        //code to grab potion
                        currentPotion = hitInfo.transform.gameObject;

                        p = hitInfo.transform.gameObject.GetComponent<PotionProperty>();

                        currentPotion.transform.SetParent(container.transform);
                        currentPotion.transform.localPosition = new Vector3(.75f, -0.75f, 0.0f); ;
                        currentPotion.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        currentPotion.transform.localScale = Vector3.one;

                        hasPotion = true;
                    }
                }

                //if pot is selected
                else if (hitInfo.transform.gameObject.tag == "Pot")
                {
                    Debug.Log("You've hit the pot");
                    // if holding potion
                    if (hasPotion)
                    {
                        Debug.Log("You're currently holding a potion");
                        //get information of potion
                        bool potionFull = p.potionFull;

                        // if holding empty potion
                        if (!potionFull)
                        {
                            Debug.Log("Your potion is empty.");
                            // pot not empty, take potion from pot
                            // pot empty, do nothing
                            Debug.Log(pm.potEmpty);
                            if (!pm.potEmpty)
                            {
                                Debug.Log("filling your potion..");
                                // code to take potion from pot
                                p.FillPotion(pm.FillPotion());
                            }
                        }
                        else  // if holding full potion
                        {
                            Debug.Log("Your potion is full.");
                            //pot not full, pour potion in
                            //pot is full, do nothing
                            if (!pm.potFull)
                            {
                                Debug.Log("You can pour the potion into the pot.");
                                // pour potion in
                                pm.PourIn(p.c);
                                // empty potion
                                p.EmptyPotion();
                            }
                        }
                    }
                }

                else if (hitInfo.transform.gameObject.tag == "MixingStick")
                {
                    pm.Mix();
                }
                else if (hitInfo.transform.gameObject.tag == "CompareButton") {
                    if (hasPotion) {
                        // insert call compare method code here
                        mpc.ColorComparer(currentPotion);
                    }
                }
                else if (hitInfo.transform.gameObject.tag == "Trash") {
                    if (hasPotion)
                    {
                        p.EmptyPotion();
                    }
                    /*else if (hasPot) {
                        pm.EmptyPot();
                    }*/
                }
                else //if holding potion, drop potion. if holding pot, drop pot
                {
                    if (hasPotion)
                    {
                        currentPotion.GetComponent<PotionControl>().Snapback();
                        hasPotion = false;
                        currentPotion.transform.SetParent(null);

                    }
                  /*  else if (hasPot) {
                        hasPot = false;
                        pm.Snapback();
                        mixingPot.transform.SetParent(null);
                    }*/
                }
            }
        }
    }
}
