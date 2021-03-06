using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTimer_Tay_V2 : MonoBehaviour
{
    //PSEUDOCODE:
    //On load, set canvas color and TMPro (Blue, "Instructions". Wait for player to click the Canvas element
    //On player click, change canvas color and TMPro (Red; "wait for green"). At random interval (min 1, max 5)
    //If player click is timely, change state of canvas color and TMPro (Green, "click now!")
    //Else if player click is too soon, change canvas color and TMPro (Blue; "Too soon!"). Restart game.
    //Start the timer in update function (var =+ Time.deltaTime)
    //On player click, change canvas color and TMPro(Blue, "Your time is: "), Display elapsed time.

    public Image bgColor;
    public TextMeshProUGUI uiText;

    public AudioSource audioSource;
    public AudioClip startSound;
    public AudioClip endSound;
    public AudioClip warningSound;

    private bool waitTimerActive; //starts and stops the waitTimer
    private bool waitTimerReset; //restarts timer if interrupted.
    private float waitTimer; //is assigned a random interval and counts down to 0.
    private float waitMinSec = 1f; //minimum number of seconds timer will be assigned.
    private float waitMaxSec = 5f; //maximum number of seconds timer will be assigned.

    private bool reactionTimerActive;
    private float reactionTime;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        //Set initial values of the game and provide player with instruction.
        bgColor.color = Color.cyan;
        uiText.color = Color.white;
        uiText.text = "Welcome! \n When the box turns green, click as quickly as you can.";
        waitTimerActive = false;
        reactionTimerActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //waitTimer start: count down to 0 from random interval.
        //waitTimer stop: present reactScreen and start reactTimer.

        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            bgColor.color = Color.red;
            uiText.text = "Wait for green...";

            waitTimerActive = true;
            waitTimer = Random.Range(waitMinSec, waitMaxSec);
            Debug.Log("There's now: " + waitTimer + " placed on the clock");

            if (waitTimer > 0 && waitTimerActive == true) {
                waitTimer -= Time.deltaTime * 1;
                Debug.Log(waitTimer);

            } else if (waitTimer > 0 && Input.GetKeyDown(KeyCode.Mouse0)) {
                waitTimerActive = false;
                waitTimer = 0;
            }

            if (waitTimer < 0 && waitTimerActive == true) {
                reactionTimerActive = true;
                waitTimerActive = false;
                waitTimer = 0;
                bgColor.color = Color.green;
                uiText.text = "Click!";
            }

            if (waitTimerActive == false && reactionTimerActive == false)
            {
                bgColor.color = Color.blue;
                uiText.text = "Toon Soon! Click to try again.";
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                bgColor.color = Color.red;
                uiText.text = "Wait for green...";

                waitTimerActive = true;
                waitTimer = Random.Range(waitMinSec, waitMaxSec);
                Debug.Log("There's now: " + waitTimer + " place on the clock");
            }
        }
        
        /*if (waitTimer > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            waitTimerActive = false;
            bgColor.color = Color.blue;
            uiText.text = "Too Soon!";
        }*/
        //start reactTimer; count up.
        //store point of player reaction;
    }

    /*void LoadGame() {
        //use this to return game to init state.
    }

    void RestartTimer() {
        waitTimerActive = false;
        waitTimer = 0;
    }
    void WaitTimer() {
        
    }
    void ReactTimer() {
        reactionTimerActive = false;
        reactionTime = 0;
    }*/
}
