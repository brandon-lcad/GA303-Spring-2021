using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTimer_Hikari : MonoBehaviour {
    private float elapsedTime; // This is the total number of seconds since the timer was reset
    private float reactionTime; // This is the milliseconds between the start and stop time

    private bool timerStarted; // This is turned off by default and on when the timer is started
    private bool timerStopped; // This is turned off by default and on when the User taps space
    private bool testFailed; // This is turned off by default and on when the User taps too early

    public float minSeconds = 1f;
    public float maxSeconds = 10f;
    private float randomSeconds; // This is a random number between minSeconds and maxSeconds

    public Image background; // A reference to the background image on the Canvas
    public TextMeshProUGUI screenText; // A reference to the text on the Canvas
    public Sprite waitcatImage; // Image to use when waiting
    public Sprite nyeehawImage; // Image to use when too early
    public Sprite nowcatImage; // Image to use for timer up
    public Sprite goodjobImage; // Image to give User a thumb up

    public AudioSource audioSource;
    public AudioClip startSound; // A short sound effect that plays when the timer starts
    public AudioClip stopSound; // A short sound effect that plays when the timer stops
    public AudioClip tooEarlySound; // For when you jump the gun

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        ResetTimer();
    }

    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;

        if (!timerStarted && !testFailed) { // The timer has not yet started
            Debug.Log("Wait...");
            if (elapsedTime >= randomSeconds) {
                StartTimer();
            } else {
              if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
                  Debug.Log("Too Soon...");
                  FalseStart();
              }
            }
        } else if (timerStarted && !timerStopped && !testFailed) { // The timer is currently running
            Debug.Log("Start...");
            reactionTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
                Debug.Log("Stop...");
                StopTimer();
            }
        } else if ((timerStarted && timerStopped) || testFailed) { // The User has stopped the timer
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
        testFailed = false;
        background.sprite = waitcatImage;
        SetScreen(new Color(255, 255, 255, 255), "Wait for green.");
        audioSource.Stop();
    }

    void StartTimer() {
        timerStarted = true;
        SetScreen(new Color(0, 150, 0, 255), "Tap!");
        background.sprite = nowcatImage;
        PlayAudioClip(startSound);
    }

    void FalseStart() {
        testFailed = true;
        SetScreen(new Color(255, 255, 255, 255), "You jumped the gun, partner! Try again.");
        PlayAudioClip(tooEarlySound);
        background.sprite = nyeehawImage;
    }

    void StopTimer() {
        timerStopped = true;
        SetScreen(new Color(255, 255, 255, 255), "Reaction time: " + reactionTime + " ms. \n Click to restart.");
        background.sprite = goodjobImage;
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
