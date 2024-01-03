using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Spawner_Random_Colors : MonoBehaviour
{
    [SerializeField]
    private Material[] r_Colors = null;

    [SerializeField]
    public GameObject SelfDrivingPrefab;

    [SerializeField]
    public float DropTime;

    private float _timer;
    private bool _firstSpawn;

    private void Start()
    {
        _firstSpawn = true;

        if (r_Colors == null)
            Debug.Log("ASSIGN MATERIALS!!!!");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        int random = Random.Range(0, r_Colors.Length);

        if(_timer >= DropTime || _firstSpawn)
        {
            _firstSpawn = false;

            SelfDrivingPrefab.gameObject.GetComponentInChildren<Renderer>().material = r_Colors[random];

            Instantiate(SelfDrivingPrefab, this.transform);

            _timer = 0;
        }
    }

    public float GetDropTime()
    {
        return DropTime;
    }
}
