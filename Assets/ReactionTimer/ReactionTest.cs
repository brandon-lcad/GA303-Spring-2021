using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class ReactionTest : MonoBehaviour {
    private float elapsedTime; // This is the total number of seconds since the timer was reset
    private float reactionTime; // This is the milliseconds between the start and stop time

    private bool timerStarted; // This is turned off by default and on when the timer is started
    private bool timerStopped; // This is turned off by default and on when the User taps space 

    public float minSeconds = 1f;
    public float maxSeconds = 10f;
    private float randomSeconds; // This is a random number between minSeconds and maxSeconds

    public Image background; // A reference to the background image on the Canvas
    public TextMeshProUGUI screenText; // A reference to the text on the Canvas

    public AudioSource audioSource; 
    public AudioClip startSound; // A short sound effect that plays when the timer starts
    public AudioClip stopSound; // A short sound effect that plays when the timer stops

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        ResetTimer();
    }

    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;

        // The timer has not yet started 
        if (!timerStarted) {
            Debug.Log("Wait...");
            if (elapsedTime >= randomSeconds) {
                StartTimer();
            }

        // The timer is currently running
        } else if (timerStarted && !timerStopped) {
            Debug.Log("Start...");
            reactionTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
                Debug.Log("Stop...");
                StopTimer();
            }
        }

        // The User has stopped the timer
        else if (timerStarted && timerStopped) {
            Debug.Log("Reset...");
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
                ResetTimer();
            }
        }
    }

    void ResetTimer() { // Reset the timer to it's default values
        elapsedTime = 0f; 
        reactionTime = 0f;
        timerStarted = false;
        timerStopped = false; 
        randomSeconds = Random.Range(minSeconds, maxSeconds);
        SetScreen(new Color(150, 0, 0, 255), "Wait for green."); 
    }

    void StartTimer() {
        timerStarted = true;
        SetScreen(new Color(0, 150, 0, 255), "Tap!"); 
        PlayAudioClip(startSound);
    }

    void StopTimer() {
        timerStopped = true;
        SetScreen(new Color(0, 0, 0, 255), "Reaction time: " + reactionTime + " ms. \n Click to restart.");
        PlayAudioClip(stopSound);
    }

    void SetScreen(Color color, string text) {
        background.color = color;
        screenText.text = text; 
    }

    void PlayAudioClip(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
