using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_Heather : MonoBehaviour
{
    int min;
    int max;
    int guess;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        Debug.Log("Hey there, glad you could make it to this very serious mandatory exercise.");
        Debug.Log("Go ahead and think of a number between 540,604,950 and 168,456,112,005, and I'll guess what it is.");
        Debug.Log("I'm kidding, pick a number between " + min + " and " + (max - 1));
        Debug.Log("If your number is larger than my guess, press the up arrow. If it's lower, press the down arrow.");
        Debug.Log("Is your number higher or lower than " + guess + "?");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Guess();
        }

        if (gameOver)
        {
            Replay();
        }

    }

    void StartGame()
    {
        min = 1;
        max = 1995;
        gameOver = false;

        guess = Random.Range(min, max);
    }

    void Guess()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;
            guess = Random.Range(min, max);
            Debug.Log("Is it " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess - 1;
            guess = Random.Range(min, max);
            Debug.Log("Is it " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameOver = true;

            if (guess == 69 || guess == 420)
            {
                Debug.Log("Wow. So mature. We're done here.");
                UnityEditor.EditorApplication.isPlaying = false;
            }

            else if (guess == 666)
            {
                Debug.Log("Oooooo, so scary.");
                Debug.Log("Anyways. Did you want to play again, or would you rather go sacrifice a goat? Y/N");
            }

            else {
                Debug.Log("Of course it is, I'm a freakin' genius. Want to play again? Y/N");
            }
        }
    }

    void Replay()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Well too bad, I'm tired. We're done here");
            Debug.Log("Ugh, fine.");
            StartGame();
            Debug.Log("Is your number higher or lower than " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Thank god.");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
