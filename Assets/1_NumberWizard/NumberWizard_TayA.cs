using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_TayA : MonoBehaviour
{
    //Type?, Name it, = a value

    //variables are scoped. Declared in Start can only be used in start. Same with update.
    //For them to me used in both places, declare the variables here, under Class

    int min;
    int max;
    int guess;


    // Start is called before the first frame update
    void Start()
    {
        //Intro
        //Explain the controls
        //Tell player to pick a number between a minimum and maximum

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess +1;
            
            guess = Random.Range(min, (max));
            Debug.Log("Is your number higher or lower than " + guess + "?");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess - 1;

            guess = Random.Range(min, max);
            Debug.Log("Is your number higher or lower than " + guess + "?");
        } else if(Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("I'm the winner!");
            StartGame();
        }
    }

    void StartGame()
    {
        min = 1;
        max = 100;
 
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Up Arrow = Your number is higher than my guess. \n " +
            "Down arrow = your number is lower than my guess. \n" +
            "Enter key = I guessed correctly \n");
        Debug.Log("Pick a number between " + min + " and " + (max - 1));

        guess = Random.Range(min, (max + 1));
        Debug.Log("Is your number higher or lower than " + guess + "?");
    }
}
