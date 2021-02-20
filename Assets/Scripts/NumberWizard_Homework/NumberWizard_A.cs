using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_A: MonoBehaviour

{
    int min = 1;
    int max = 20;
    int guess = 10;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" Welcome To number Wizard ");
        Debug.Log(" Pick a number between" + min + "and" + max);
        Debug.Log(" I bet I can guess your number ");
        Debug.Log(" Pick Up or Down if your number is low or high");
        Debug.Log(" Press Enter if your number is correct");
        Debug.Log(" Is your number" + guess + "?");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess; //Now the minimum is equal to 10 (now minimum takes place of the guess, the new min is 10)
            guess = (max + min) / 2;
            Debug.Log("Is your number" + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess; //Now the minimum is equal to 10 (now maximum takes place of the guess, the new max is 10)
            guess = (max + min) / 2;
            Debug.Log("Is your number" + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.Return)) 
        { 
         Debug.Log("I got it. Your number is " + guess);
        }
    }

}
