using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_Hikari : MonoBehaviour
{
  int min;
  int max;
  int guess;

    void Start()
    {
        Debug.Log("Welcome to Number Wizard!!");
        Debug.Log("Press the -up arrow key- if your number is higher than my guess. Press the -down arrow key- if your number is lower than my guess. Press -Enter- if I guessed your number!");
        StartGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = (guess +1);

            guess = Random.Range(min, max);
            Debug.Log("Is your number higher or lower than: " + guess + "?");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;

            guess = Random.Range(min, max);
            Debug.Log("Is your number higher or lower than: " + guess + "?");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Wait, I got it? HUZZAH! The Number Wizard does it again!!");
            Debug.Log("Wanna go again? y/n");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Once more then!!");
            StartGame();
        }

          else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Buh bye!");
        }
    }

    void StartGame()
    {
        min = 1;
        max = 1001;

        Debug.Log("Think of a number, any number, between " + min + " and " + (max -1) + ", and I shall guess what number you're thinking of!");

        guess = Random.Range(min, max);
        Debug.Log("Is your number higher or lower than: " + guess + "?");
    }
}
