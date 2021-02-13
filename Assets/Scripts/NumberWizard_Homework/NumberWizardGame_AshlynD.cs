using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizardGame_AshlynD : MonoBehaviour
{
    int min;
    int max;
    int guess;
  
    void Start()
    {
        Startgame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;

            guess = Random.Range(min, max);
            Debug.Log("So its higher huh? Lemme try again");
        }  
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;

            guess = Random.Range(min, max);
            Debug.Log("So its lower huh? Lemme try again");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I won!!!");

            Startgame();
        }
    }

    void Startgame()
    {
        min = 1;
        max = 1001;
       
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Up Arrow = your number is higher than my guess, Down Arrow = your number is lower than my guess, Enter = I guessed correctly");
        Debug.Log("Pick a number between " + min + " and " + (max - 1));

        guess = Random.Range(min, max);
        Debug.Log("Is your number higher or lower than: " + guess);
    }
}
