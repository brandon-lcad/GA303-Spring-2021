using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour {
    public string name = "Simon";
    public int age = 21;
    [SerializeField] [Range(60, 85)] private int height = 70;
    [SerializeField] private bool gettingSad = false;
    [Range(0, 100)] public float happiness = 100f;
    [Range(0, 100)] public float health = 100f; 

    // Start is called before the first frame update
    void Start() { } 

    // Update is called once per frame
    void Update() {
        if (gettingSad) {
            happiness -= Time.deltaTime; 
        }
    }

    // VOID means I expect you to return NOTHING 
    public void WhatIsGettingSad() {
        Debug.Log("Right now, the 'gettingSad' value is " + gettingSad); 
    }

    public bool GetTheGettingSadValue() {
        return gettingSad; 
    }

    public int GetTheHeightValue() {
        return height; 
    }

    public void GettingSad (bool sad) { // GettingSad(true) or GettingSad(false)
        bool oldValue = gettingSad; 
        gettingSad = sad;
        Debug.Log("The 'gettingSad' variable was " + oldValue + "and is now " + gettingSad); 
    }

    public int GoobleyGobbley(int x, int y) { // DoTheMaths(1,2) or DoTheMaths(5,5)
        return x + y; 
    }

}
