using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float walkSpeed = 5f;

    [SerializeField] bool cursorLocked = true;

    float cameraPitch = 0.0f;
    UnityEngine.CharacterController controller = null;

    // Start is called before the first frame update
    void Start()
    {
        //initalizing the character controller
        controller = GetComponent<UnityEngine.CharacterController>();

        //keeping the cursor in place
        if (cursorLocked) {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        updateMouseLook();
        updatePlayerMovement();
    }

    void updateMouseLook() {

        Vector2 mouseChange = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //calculating y change of camera, but keeping it within a +-90 degree range
        cameraPitch -= mouseChange.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        // rotating the camera upon mouse movement
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseChange.x * mouseSensitivity);

    }

    void updatePlayerMovement() {

        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputDir.Normalize();

        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;

        controller.Move(velocity * Time.deltaTime);
    }
}
