using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningWheel : MonoBehaviour
{
    private Quaternion _startRotation;

    // Start is called before the first frame update
    void Start()
    {
        _startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            transform.Rotate(Vector3.up, 45.0f);
        }
        if(Input.GetKeyUp(KeyCode.Q)) //Reset Button
        {
            transform.rotation = _startRotation;
        }

    }
}
