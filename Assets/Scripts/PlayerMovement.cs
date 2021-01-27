using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Transform tf;

    public float speed;

    public float lookDirection;

    public GameObject PlayerHead;

    public float jumpVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    void FixedUpdate()
    {

         float InputForward = Input.GetAxis("Vertical");
         float InputSide = Input.GetAxis("Horizontal");

         Vector3 moveDir = (transform.right * InputSide + transform.forward * InputForward) * speed;

         rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
    }
}
