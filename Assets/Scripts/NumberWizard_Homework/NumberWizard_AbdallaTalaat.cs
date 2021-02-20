using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_AbdallaTalaat : MonoBehaviour
{
    int max = 30; 
    int min = 1;
    int guess = 15; 

    void Start()
    {
        Debug.Log("Hello there travel!");

        Debug.Log("Pick a number between" + min + " and " + max + " and I know I can tell you what it is.");

        Debug.Log("Is your number higher than, lower than, or exactly " + guess + "?");

        Debug.Log("If it's higher, press UP. If it's lower, press DOWN. If it's correct, press Enter.");

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))  
        {
            min = guess;
            guess = (max + min) / 2;
            Debug.Log("Higher? Is your number " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (max + min) / 2;
            Debug.Log("Lower? your number is " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("YUS, I got your number " + guess + "!");
        }
    }
}
