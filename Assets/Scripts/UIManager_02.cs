using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager_02 : MonoBehaviour
{
    public float MAX_SCORE_Green, MAX_SCORE_Blue, MAX_SCORE_Red;

    private Text _greenText, _blueText, _redText;
    private float _internalTimer, _endTime;


    // Start is called before the first frame update
    void Start()
    {
        _greenText = GameObject.Find("Green Text").GetComponent<Text>();
        _greenText.text = "0";

        _redText = GameObject.Find("Red Text").GetComponent<Text>();
        _redText.text = "0";

        _blueText = GameObject.Find("Blue Text").GetComponent<Text>();
        _blueText.text = "0";
    }

    public void UpdateScoreGreen()
    {
        float score = float.Parse(_greenText.text);

        score += 1;

        _greenText.text = score.ToString();
    }

    public void UpdateScoreRed()
    {
        float score = float.Parse(_redText.text);

        score += 1;

        _redText.text = score.ToString();
    }

    public void UpdateScoreBlue()
    {
        float score = float.Parse(_blueText.text);

        score += 1;

        _blueText.text = score.ToString();
    }
}
