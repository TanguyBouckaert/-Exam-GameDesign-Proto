using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class HangarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hangars;

    [SerializeField]
    private Material highlightMaterial, defaultMaterial;


    private float _timer;

    [SerializeField]
    private float changeTime_InSeconds;

    private void Start()
    {
        foreach (var hangar in hangars)
        {
            if(hangar.GetComponent<Renderer>() == null)
            {
                Debug.Log($"{hangar.name} has no material!!!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        int random = Random.Range(0, hangars.Length);

        if (_timer >= changeTime_InSeconds)
        {
            hangars[random].GetComponent<Renderer>().sharedMaterial = highlightMaterial;
            _timer = 0;
        }

        if(_timer >= changeTime_InSeconds/2)
        {
            foreach (var hangar in hangars)
            {
                hangar.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
            }
        }

    }
}
