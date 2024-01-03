using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public float Hours, Min, Sec, MAX_SCORE;

    private Text _timerLable, _scoreLable;
    private float _internalTimer, _endTime;


    // Start is called before the first frame update
    void Start()
    {
        _endTime = (Hours * 3600) + (Min * 60) + Sec;
        _timerLable = GameObject.Find("Time Text").GetComponent<Text>();
        _timerLable.text = "00:00";

        _scoreLable = GameObject.Find("Score Text").GetComponent<Text>();
        _scoreLable.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        _internalTimer += Time.deltaTime;
        TimeSpan _temp = TimeSpan.FromSeconds(_internalTimer);
        _timerLable.text = new TimeSpan(_temp.Hours, _temp.Minutes, _temp.Seconds).ToString("g");

        if(_internalTimer >= _endTime)
        {
            _timerLable.text = "GAME OVER";
        }

        CheckWinningState(float.Parse(_scoreLable.text));
    }


    private void CheckWinningState(float score)
    {
        if (score == MAX_SCORE)
            _timerLable.text = "YOU WIN";
    }

    public void UpdateScore()
    {
        float score = float.Parse(_scoreLable.text);

        score += 1;

        _scoreLable.text = score.ToString();
    }
}
