using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject DriveTrainPrefab, SelfDrivingPrefab;

    [SerializeField]
    public bool SelfDriving = false;

    [SerializeField]
    public float DropTime;

    private float _timer;
    private bool _firstSpawn;

    private void Start()
    {
        _firstSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= DropTime || _firstSpawn)
        {
            _firstSpawn = false;
            if(SelfDriving)
            {
                Instantiate(SelfDrivingPrefab, this.transform);
            }
            else
            {
                Instantiate(DriveTrainPrefab, this.transform);
            }
            _timer = 0;
        }
    }

    public float GetDropTime()
    {
        return DropTime;
    }
}
