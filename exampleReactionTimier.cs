using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public float delay = 3.0f;
    public float timer = 0.0f;
    public bool startTime = false;
    public bool resetTime = false;
    public Button button;
    public Text buttonText;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            TimeIt();
        }
        else
        {
            CountDown();
        }
    }

    void TimeIt()
    {
        startTime = true;
        button.interactable = true;
        buttonText.text = "Click me!";
        timer += Time.deltaTime;
    }

    void CountDown()
    {
        if (delay > 0)
        {
            buttonText.text = "Ready in ... " + delay.ToString("f0");
            delay -= 1 * Time.deltaTime;
        }
        else
        {
            startTime = true;
        }
    }

    public void ResetTimerToggle()
    {
        resetTime = !resetTime;
        if (resetTime)
        {
            button.interactable = false;
            delay = 3.0f;
            Debug.Log("Resetting timers.");
        }
    }

    public void ShowTimer()
    {
        timerText.text = string.Format("{0:0.000}", timer);
    }
}
