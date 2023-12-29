using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDrivingTrain : MonoBehaviour
{
    [SerializeField]
    public float Speed;

    private bool _drive = true;
    private float _actualSpeed = 2.5f;

    private void Update()
    {
        //Makes the train stop when it is required!
        if (_drive)
            _actualSpeed = Speed;
        if (!_drive)
            _actualSpeed = 0;

       transform.Translate(Vector3.forward * _actualSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("WaitTrigger"))
        {
            _drive = false;
        }
    }
}
