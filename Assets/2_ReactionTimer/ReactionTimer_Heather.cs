using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTimer_Heather : MonoBehaviour
{
    private float elapsedTime; // This is the total number of seconds since the timer was reset
    private float reactionTime; // This is the milliseconds between the start and stop time
    public float maxTime; // This is the amount of time before the reaction test is failed

    private bool timerStarted; // This is turned off by default and on when the timer is started
    private bool timerStopped; // This is turned off by default and on when the User taps space 

    public float minSeconds = 1f;
    public float maxSeconds = 10f;
    private float randomSeconds; // This is a random number between minSeconds and maxSeconds


    public Image background; // A reference to the background image on the Canvas
    public TextMeshProUGUI screenText; // A reference to the text on the Canvas

    public Sprite defaultBackground; // Default Image to display
    public Sprite earlyBackground; // Image to display when User clicks too soon
    public Sprite lateBackground; // Image to display when reaction test is failed

    public AudioSource audioSource;
    public AudioClip startSound; // A short sound effect that plays when the timer starts
    public AudioClip stopSound; // A short sound effect that plays when the timer stops
    public AudioClip earlySound; // A short sound effect that plays when the page is clicked before the timer starts
    public AudioClip lateSound; // A short sound effect that plays when the timer is not stopped within a set period of time

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // The timer has not yet started 
        if (!timerStarted)
        {
            Debug.Log("Wait...");
            if(elapsedTime <= randomSeconds && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                EarlyStop();
            }

            if (elapsedTime >= randomSeconds)
            {
                StartTimer();
            }

        // The timer is currently running
        }

        else if (timerStarted && !timerStopped)
        {
            Debug.Log("Start...");
            reactionTime += Time.deltaTime;

            if (reactionTime < maxTime && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Stop...");
                StopTimer();
            }
            else if (reactionTime > maxTime)
            {
                LateStop();
            }
        }

        // The User has stopped the timer
        else if (timerStarted && timerStopped)
        {
            Debug.Log("Reset...");
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                ResetTimer();
            }
        }
    }

    void ResetTimer()
    { // Reset the timer to it's default values
        elapsedTime = 0f;
        reactionTime = 0f;
        timerStarted = false;
        timerStopped = false;
        randomSeconds = Random.Range(minSeconds, maxSeconds);
        SetScreen(new Color(150, 0, 0, 255), "Wait for green.");
        background.sprite = defaultBackground;
    }

    void StartTimer()
    {
        timerStarted = true;
        SetScreen(new Color(0, 150, 0, 255), "Tap!");
        background.sprite = defaultBackground;
        PlayAudioClip(startSound);
    }

    void EarlyStop()
    { 
        timerStarted = true;
        timerStopped = true;
        SetScreen(new Color(255, 255, 255, 255), "Patience is a virtue.");
        background.sprite = earlyBackground;
        PlayAudioClip(earlySound);
        StartCoroutine(RestartTest(3f));
    }

    void LateStop()
    {
        timerStopped = true;
        SetScreen(new Color(255, 255, 255, 255), "Wow, that's pretty bad. \n Click to restart");
        background.sprite = lateBackground;
        PlayAudioClip(lateSound);
    }

    void StopTimer()
    {
        timerStopped = true;
        SetScreen(new Color(0, 0, 0, 255), "Reaction time: " + reactionTime + " ms. \n Click to restart");
        background.sprite = defaultBackground;
        PlayAudioClip(stopSound);
    }

    void SetScreen(Color color, string text)
    {
        background.color = color;
        screenText.text = text;
    }

    void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator RestartTest(float time)
    {
        yield return new WaitForSeconds(time);
        ResetTimer();
    }

}
