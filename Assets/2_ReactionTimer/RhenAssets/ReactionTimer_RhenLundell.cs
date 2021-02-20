using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTimer_RhenLundell : MonoBehaviour
{
    private float totalTime;
    private float reactionTime;

    private bool timerStarted;
    private bool timerStopped;

    public float minSeconds = 1f;
    public float maxSeconds = 5f;
    private float randomSeconds;

    public Image background;
    public TextMeshProUGUI screenText;

    public AudioSource audioSource;
    public AudioClip startSound;
    public AudioClip stopSound;

    public Color backgroundRed;
    public Color backgroundBlue;
    public Color backgroundGreen;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Reset...");
        ResetTimer();
    }

    void Update()
    {
        totalTime += Time.deltaTime;

        if (!timerStarted)
        {
            Debug.Log("Wait...");

            if (totalTime >= randomSeconds)
            {
                StartTimer();
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Stop...");
                BadTimer();
            }

        }

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
    {
        totalTime = 0f;
        reactionTime = 0f;
        timerStarted = false;
        timerStopped = false;
        randomSeconds = Random.Range(minSeconds, maxSeconds);
        SetScreen(backgroundRed, "Click when you see green.");
    }

    void StartTimer()
    {
        timerStarted = true;
        SetScreen(backgroundGreen, "Click!");
        PlayAudioClip(startSound);
    }

    void StopTimer()
    {
        timerStopped = true;
        SetScreen(backgroundBlue, "Reaction Time: " + reactionTime + " ms. \n Click to restart.");
        PlayAudioClip(stopSound);
    }

    void BadTimer()
    {
        timerStopped = true;
        timerStarted = true;
        SetScreen(backgroundRed, "Too soon! \n Click to restart.");
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
}