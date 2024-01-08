using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 2.5f;


    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal_Joystick_Right");
        float vert = Input.GetAxis("Vertical_Joystick_Right");

        Vector3 moveDirection = new Vector3(horiz, vert, 0f);

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 moveVector = new Vector3(moveDirection.x, moveDirection.y, 0f);
            Vector3 moveDirectionWorld = Camera.main.transform.TransformDirection(moveVector);

            transform.Translate(moveDirectionWorld * cameraSpeed * Time.deltaTime, Space.World);
        }


        //if (horiz  > 0 || horiz < 0 || vert > 0 || vert < 0)
        //    transform.Translate(new Vector3(horiz, transform.position.y, vert) * Time.deltaTime);
    }
}
