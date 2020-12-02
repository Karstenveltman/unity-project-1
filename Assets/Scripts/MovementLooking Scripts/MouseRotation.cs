using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private Transform tf;

    public Transform playerTf;

    public float xRotation;

    public float yRotation;

    public float mouseSensitivity;



    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -=mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        playerTf.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        tf.localRotation = Quaternion.Euler(xRotation, 0f ,0f);
    }
}
