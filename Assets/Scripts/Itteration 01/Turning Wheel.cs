using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningWheel : MonoBehaviour
{
    [SerializeField]
    private float wheelTurningAngel = 45.0f, minAngle = -45.0f, maxAngle = 45.0f, rotationSpeed = 5.0f;

    [SerializeField]
    private GameObject leftSide, rightSide;

    private Quaternion _startRotation;
    private bool _hasturned = false;
    // Start is called before the first frame update
    void Start()
    {
        _startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxisValue = Input.GetAxis("Horizontal");

        if (hAxisValue > 0 || hAxisValue < 0)
        {
            switch (hAxisValue > 0)
            {
                case true:
                    leftSide.SetActive(false);
                    rightSide.SetActive(true);
                    break;
                case false:
                    rightSide.SetActive(false);
                    leftSide.SetActive(true);
                    break;
            }

            float targetRotation = wheelTurningAngel * Input.GetAxis("Horizontal");
            //SmoothRotate(Vector3.up, targetRotation); 
        }

        if (!_hasturned && hAxisValue > 0.0f)
        {
            transform.Rotate(Vector3.up, -25.0f);
            _hasturned = true;
        }
        if (!_hasturned && hAxisValue < 0.0f)
        {
            transform.Rotate(Vector3.up, 25.0f);
            _hasturned = true;
        }
        if (_hasturned && hAxisValue == 0.0f)
        {
            transform.Rotate(Vector3.up, 0.0f);
            _hasturned = false;
        }


        //if(Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    transform.Rotate(Vector3.up, wheelTurningAngel);
        //    //SmoothRotate(Vector3.up, wheelTurningAngel);
        //}
        if (Input.GetKeyUp(KeyCode.Q)) //Reset Button
        {
            transform.rotation = _startRotation;
        }
    }
    void SmoothRotate(Vector3 axis, float targetAngle)
    {
        // Calculate the rotation step based on the speed and time
        float step = rotationSpeed * Time.deltaTime;

        // Calculate the current rotation angle
        float currentAngle = transform.rotation.eulerAngles.y;

        // Calculate the clamped target angle to stay within the specified range
        float clampedTargetAngle = Mathf.Clamp(targetAngle, minAngle, maxAngle);

        // Lerp between the current rotation and the clamped target rotation
        Quaternion targetRotation = Quaternion.Euler(axis * clampedTargetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, step);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E)) //Stop Block 
        {
            other.gameObject.GetComponent<SelfDrivingTrain>().Drive();
        }
    }
}
