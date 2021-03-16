using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the rotation of a GameObject using the mouse movement.
public class FirstPersonController : MonoBehaviour
{
    float xRotation = 0f;
    float yRotation = 0f;

    [SerializeField] private float xMinRotation = -90f;
    [SerializeField] private float xMaxRotation = 0;
    [SerializeField] private float yMinRotation = -90f;
    [SerializeField] private float yMaxRotation = 90f;

    [SerializeField] private float mouseSensitivity = 150f;

    void Start()
    {
        //Hides the cursor and locks it to the center of the game window.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetMouseInput();
        this.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    //Reads the mouse input and converts it into rotation angles.
    public void GetMouseInput()
    {
        xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, xMinRotation, xMaxRotation);
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, yMinRotation, yMaxRotation);
    }
}