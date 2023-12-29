using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CrainController : MonoBehaviour
{
    private Transform _crainPillar, _crainArm, _crainCable, _crainGrabber;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Amount of childeren in crain: {this.transform.childCount}");
        _crainPillar = transform.GetChild(0);
        _crainArm = _crainPillar.GetChild(0);
        _crainCable = _crainArm.GetChild(0);
        _crainGrabber = _crainCable.GetChild(0);


        //Check if everything is assinged!!!
        Assert.IsNotNull(_crainArm);
        Assert.IsNotNull(_crainCable);
        Assert.IsNotNull(_crainGrabber);

    }

    // Update is called once per frame
    void Update()
    {

        //Turn crain One way (Which one I don't know!)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _crainPillar.transform.Rotate(Vector3.up, 45.0f, Space.Self);
        }
        //Turn crain The other way
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _crainPillar.transform.Rotate(Vector3.up, -45.0f,Space.Self);
        }

        //Extend crain arm forward
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _crainArm.transform.localScale += new Vector3(0, 0, 5.0f);
        }
        //Extend crain arm backward
        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            _crainArm.transform.localScale += new Vector3(0, 0, -5.0f);
        }

        //Lower crain cable
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _crainCable.transform.localScale += new Vector3(0, 0, 5.0f);
        }
        //Lower crain cable
        if (Input.GetKeyDown(KeyCode.E))
        {
            _crainCable.transform.localScale += new Vector3(0, 0, -5.0f);
        }


    }
}
