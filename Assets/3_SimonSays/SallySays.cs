using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SallySays : MonoBehaviour {
    private SimonSays simon;
    [SerializeField] private float damageMultiplier = 1f;

    public int[] aArrayOfNumbers;
    public string[] aArrayOfStrings;
    public List<string> aListOfStrings = new List<string>();

    void Awake() { 
        damageMultiplier = 0f; 
        simon = GetComponent<SimonSays>();
        Debug.Log("Hi.");
        Debug.Log("Oh. I see your name is " + simon.name);
        Debug.Log("You are " + simon.age + " years old"); 

        simon.WhatIsGettingSad();
        
        bool theGettingSadValue = simon.GetTheGettingSadValue();
        Debug.Log("The value that you got was " + theGettingSadValue);

        int theHeightValue = simon.GetTheHeightValue(); 
        Debug.Log("The height value, which I cannot change, is " + theHeightValue);

        int x = Random.Range(0, 100);
        int y = Random.Range(0, 100);
        int theMathsAnswer = simon.GoobleyGobbley(x, y);
        Debug.Log(x + " plus " + y + " equals " + theMathsAnswer);

    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("Damage Multiplier = " + damageMultiplier);
        damageMultiplier = (100 - simon.happiness) * 0.1f;
        // Example: (100 - 100 * 0.1f) = 0 
        // Example: (100 - 99 * 0.1f) = 1 * 0.1f = 0.1f; 
        // Example: (100 - 98 * 0.1f) = 2 * 0.1f = 0.2f;

        if (simon.health > 0f) {
            simon.health -= Time.deltaTime * damageMultiplier;
        } else {
            simon.health = 0f; 
        }

        //simon.height = 0;  
    }
}
