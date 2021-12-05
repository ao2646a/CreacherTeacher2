using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public LayerMask obstacleLayerMask;

    public float distance = 10;
    public float minVerticalAngle = -80;
    public float maxVerticalAngle = 80;

    public float verticalSpeed = 300;
    public float horizontalSpeed = 300;

    private float pitch;
    private float yaw;

    void Start()
    {
        pitch = -30;
        pitch = 0;
    }

    void Update()
    {
        //yaw
        yaw += Input.GetAxis("Mouse X") * Time.deltaTime * horizontalSpeed;


        //pitch
        pitch += Input.GetAxis("Mouse Y") * Time.deltaTime * verticalSpeed;


        Vector3 offset = Vector3.forward;


        offset = Quaternion.AngleAxis(pitch, Vector3.right) * offset;
        offset = Quaternion.AngleAxis(yaw, Vector3.up) * offset;
        offset *= distance;

        transform.position = target.position + offset;

        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

        PlayerController pc = target.GetComponent<PlayerController>();
        pc.forward = transform.forward;
        pc.right = transform.right;
    }
}

