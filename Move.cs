using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;
    CharacterController character;
    public GameObject cam;
    float moveFB, moveLR;
    float rotX, rotY;
    public bool ClickRotation = true;
    float gravity = -9.8f;


    void Start()
    {
        character = GetComponent<CharacterController>();
        if (Application.isEditor)
        {
            ClickRotation = false;
            sensitivity = sensitivity * 1.5f;
        }
    }

    void CheckForWaterHeigt()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }
    void Update()
    {
        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        CheckForWaterHeigt();

        Vector3 movement = new Vector3( moveFB, moveLR, gravity );

        if (ClickRotation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CameraRotation(cam,rotX, rotY);
            }
        }
        movement = transform.rotation * movement;
        character.Move(movement* Time.deltaTime);
    }
    void CameraRotation(GameObject cam,float rotX,float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate (-rotY * Time.deltaTime,0,0);
    }
}
