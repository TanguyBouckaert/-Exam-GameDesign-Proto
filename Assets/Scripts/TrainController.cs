using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        Debug.Log($"This is the location of the train: {_startPosition}.");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow)) // Map this to a the Right Trigger on a Controller
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Q)) // Map this later to a on the controller
        { 

            transform.position = _startPosition;
            transform.rotation = _startRotation;
            Debug.Log("Reset");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Your MOM!");
        transform.rotation = other.transform.rotation;
    }
}
