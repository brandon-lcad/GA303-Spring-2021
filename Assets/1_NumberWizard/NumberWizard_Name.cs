using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_Name : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Intro
        //Explain the Controls
        //Tell our player to pick a number between the minimum and maximum
        Debug.Log("Welcome to the Wizard!!");
        Debug.Log("UP Arrow = your number is higher than my guess, Down Arrow = you number is lower than my guess, Enter = I guessed correctly");
        Debug.Log("Pick a number between 1 and 1000");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
