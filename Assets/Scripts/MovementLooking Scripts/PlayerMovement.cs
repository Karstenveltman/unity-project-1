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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         //Getting inpyut from Player
         float InputForward = Input.GetAxis("Vertical");
         float InputSide = Input.GetAxis("Horizontal");

         Vector3 moveDir = (transform.right * InputSide + transform.forward * InputForward) * speed;

         rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

         if (Input.GetKeyDown("space"))
         {
           Jump();
         }
    }

    void Jump()
    {
      rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
    }
}
