using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizardGame1 : MonoBehaviour
{
    int min;
    int max;
    int guess;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();

    }

    // Update is called once per frame
    void Update()
    {

     if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;

            guess = Random.Range(min, max);
            counter++;
            Debug.Log("I have " + (5 - counter)+ " attempts left. Is your number higher or lower than: " + guess);
        }   
     else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess - 1;

            guess = Random.Range(min, max);
            counter++;
            Debug.Log("I have " + (5 - counter) + " attempts left. Is your number higher or lower than: " + guess);

        }
     else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I'm the winner!");

            StartGame();
        }
      if (counter == 5)
        { Debug.Log("I have lost.");
            StartGame();
        }


    }

    void StartGame()
    {
        min = 1;
        max = 50;
        counter = 0;

        Debug.Log("Let's play a game.");
        Debug.Log("Up Arrow = your number is higher than my guess, Down Arrow = your number is lower than my guess, Enter = I guessed correctly");
        Debug.Log("Do not lie to me.");
        Debug.Log("Pick a number between " + min + " and " + (max - 1));

        guess = Random.Range(min, max);
        Debug.Log("Is your number higher or lower than: " + guess);
    }
}
