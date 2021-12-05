using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // [HideInInspector] simply makes sure these dont pop up in the inspector.
    [HideInInspector]
    public Vector3 forward;
    [HideInInspector]
    public Vector3 right;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // movement of the ball is physics based, this is best done in FixedUpdate, since it runs synced
    // with the physics loop.
    void FixedUpdate()
    {
        forward = Vector3.forward;
        right = Vector3.right;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = forward * moveVertical + right * moveHorizontal;

        rb.AddForce(movement * speed);
    }


}