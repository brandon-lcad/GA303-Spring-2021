using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerWizardGame : MonoBehaviour
{
    int min;
    int max;
    int guess;

    void Start()
    {
        StartGame();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;

            guess = Random.Range(min, max);
            Debug.Log("Is your pokemon higher or lower than dex number: " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;

            guess = Random.Range(min, max);
            Debug.Log("Is your pokemon higher or lower than dex number: " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I guessed it :D");

            StartGame();
        }
    }

    void StartGame()
    {
        min = 1;
        max = 899;
        Debug.Log("Welcome to Rhen's Pokemon Guesser!");
        Debug.Log("Please choose a number between " + min + " and " + (max - 1) + " that corresponds to your Pokemon's number in the national dex");
        Debug.Log("If my guess is too high, hit the down arrow to tell me to go lower, likewise if my guess is too low, hit the up arrow to tell me to guess higher");
        Debug.Log("If my guess is correct, please hit the equal sign to tell me so");

        guess = Random.Range(min, max);
        Debug.Log("Is your pokemon higher or lower than dex number: " + guess);
    }
}
