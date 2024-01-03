using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDrivingTrain : MonoBehaviour
{
    [SerializeField]
    public float Speed;

    [SerializeField]
    private Rigidbody rb;

    private bool _drive = true;
    private float _actualSpeed = 2.5f;

    private void Start()
    {
        // Check if a Rigidbody component is attached
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on this object. Please attach a Rigidbody.");
        }
    }


    private void FixedUpdate()
    {
        //Makes the train stop when it is required!
        if (_drive)
            _actualSpeed = Speed;
        if (!_drive)
            _actualSpeed = 0;

       Vector3 force = Vector3.back * _actualSpeed * 1.0f;

        transform.Translate(force * Time.deltaTime);
       
        //rb.AddForce(force, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("WaitTrigger"))
        {
            _drive = false;
        }
    }


    public void Drive()
    {
        _drive = true;
        rb.AddForce(Vector3.back * _actualSpeed *1.0f);
    }
}
