using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnTimerBehaviour : MonoBehaviour
{
    private TMP_Text timerText;

    void Awake()
    {
        timerText = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    void Update()
    {
        float currentTime = GameManager.Instance.GetPlayerRespawnCounter();

        timerText.text = String.Format("{0:F1}", Math.Round(currentTime, 1)).Replace(',', '.');

        if (currentTime < 1f)
        {
            timerText.color = Color.red;
        }
        else if (currentTime < 2.5f)
        {
            timerText.color = Color.yellow;
        }
        else
        {
            timerText.color = Color.white;
        }
    }
}
