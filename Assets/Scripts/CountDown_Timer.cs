using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CountDown_Timer : MonoBehaviour
{
    public float Hours, Min, Sec;

    private Text _timerLabel;
    private float _internalTimer, _endTime;


    // Start is called before the first frame update
    void Start()
    {
        _endTime = (Hours * 3600) + (Min * 60) + Sec;
        _timerLabel = this.GetComponentInChildren<Text>();
        _timerLabel.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        _internalTimer += Time.deltaTime;
        TimeSpan _temp = TimeSpan.FromSeconds(_internalTimer);
        _timerLabel.text = new TimeSpan(_temp.Hours, _temp.Minutes, _temp.Seconds).ToString("g");

        if(_internalTimer >= _endTime)
        {
            _timerLabel.text = "GAME OVER";
        }
    }
}
