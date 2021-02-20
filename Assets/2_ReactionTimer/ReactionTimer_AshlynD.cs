using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTimer_AshlynD : MonoBehaviour
{
    private float elapsedTime; // This is the total number of seconds since the timer was reset
    private float reactionTime; // This is the milliseconds between the start and stop time

    private bool timerStarted; // This is turned off by default and on when the timer is started
    private bool timerStopped; // This is turned off by default and on when the User taps space 
    private bool tooEarly; //The player clicks too early

    public float minSeconds = 1f;
    public float maxSeconds = 10f;
    private float randomSeconds; // This is a random number between minSeconds and maxSeconds

    public Image background; // A reference to the background image on the Canvas
    public Sprite startingduck; // Image before timer 
    public Sprite tooearlyduck; // Image when clicked too early
    public Sprite waitingduck; // Image when waiting for click
    public Sprite clickduck; // Image when player clicks
    public TextMeshProUGUI screenText; // A reference to the text on the Canvas

    public AudioSource audioSource;
    public AudioClip waitingquack; // A short sound effect that plays when the timer starts
    public AudioClip clickquack; // A short sound effect that plays when the timer stops
    public AudioClip tooearlyquack; // A short sound effect that plays when the timer is clicked too early

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
            if (elapsedTime >= randomSeconds)
            {
                StartTimer();
            }
        }


        // The timer is not started, but there is a faulty click!
        if (!timerStarted)
        {
                if (elapsedTime <= randomSeconds)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        elapsedTime = 0f;
                        tooEarly = true;
                        TooEarly();
                    }

                }
        }
            // The timer is currently running
        
        else if (timerStarted && !timerStopped)
        {
            Debug.Log("Start...");
            reactionTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Stop...");
                StopTimer();
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
        screenText.text = "Wait for the menacing duck...";
        background.sprite = startingduck;
    }

    void StartTimer()
    {
        timerStarted = true;
        screenText.text = "CLICK THAT DUCK!!!";
        background.sprite = waitingduck;
        PlayAudioClip(waitingquack);
    }
    void TooEarly()
    {
        screenText.text = "THE DUCKS TOOK ADVANTAGE OF YOUR HASTE!! \n Click to restart.";
        background.sprite = tooearlyduck;
        PlayAudioClip(tooearlyquack);
        timerStarted = true;
        timerStopped = true;
        tooEarly = false;
    }
    void StopTimer()
    {
        timerStopped = true;
        background.sprite = clickduck;
        screenText.text = "Bliss... \n reaction time: " + reactionTime + "ms. \n Click to try again!";
        PlayAudioClip(clickquack);
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

}