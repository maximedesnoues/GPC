using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeRemaining = 180f;

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            UpdateTimerText();
        }
        else
        {
            Debug.Log("Le temps est écoulé!");
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}