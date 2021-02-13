using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    int max = 20; // We’re using int to signify that our value is an integer.
    int min = 1;
    int guess = 10; // Our initial guess will be 10 because it's half between 1 and 20. 

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Welcome to Number Wizard!");

        Debug.Log("Pick a number between" + min + " and " + max + " and I bet I can guess it!");

        Debug.Log("Is your number higher than, lower than, or exactly " + guess +"?");
        
        Debug.Log("If it's higher, press UP. If it's lower, press DOWN. If it's correct, press Enter.");

        max = max + 1; // Add one because it's impossible to guess exactly '20'
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess; 
            guess = (max + min) / 2;
            Debug.Log("Is your number " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess; 
            guess = (max + min) / 2;
            Debug.Log("Is your number " + guess + "?");
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Woohoo! I guessed correctly. Your number was " + guess + "!");
        }
    }
}
