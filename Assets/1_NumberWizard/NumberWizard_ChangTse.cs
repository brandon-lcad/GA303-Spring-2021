using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_ChangTse : MonoBehaviour
{
    public int truMin;
    public int truMax;
    int Min;
    int Max;
    int guess;
    int talk;
   
    void Start()
    {
        start();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            talk = Random.Range(0, 6);

        }
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Debug.Log("Higher??!?!!");
            if (talk == 1)
            {
                Debug.Log("Damn it I swore it was " + guess);
            }
            if (talk == 2)
            {
                Debug.Log("Wtf HOW IS IT NOT " + guess);
            }
            if (talk == 3)
            {
                Debug.Log("For crying out loud I hate numbers magic ");
            }
            if (talk == 4)
            {
                Debug.Log("im just jokinggggg haha... ");
            }
            if (talk == 5)
            {
                Debug.Log("leme just get out my calculator...wait why do i need a calculator");
            }
            Min = guess;
            guess = Random.Range(Min, Max);
            Debug.Log("is your number higher or lower than: " + guess);

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Lower??!?!!");
            if (talk == 1)
            {
                Debug.Log("How low do i have to go???!!!!");
            }
            if (talk == 2)
            {
                Debug.Log("I really about to give up");
            }
            if (talk == 3)
            {
                Debug.Log("12 years of Wizard school and I cant even do number magic???!!!");
            }
            if (talk == 4)
            {
                Debug.Log("wow");
            }
            if (talk == 5)
            {
                Debug.Log("*Facepalm*");
            }
            Max = guess;
            guess = Random.Range(Min, Max);
            Debug.Log("is your number higher or lower than: " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("*Wheew, I Knew your number was " +guess +" That was some hard work");
            start();
        }

    }
    void start()
    {
        Min = truMin;
        Max = truMax;
        Debug.Log("Welcome To The Number Wizard Game!!!");
        Debug.Log("Up Arrow = Highter than my guess, Down Arrow = Lower than my guess, Enter = I guessed Correct!!");
        Debug.Log(" Pick a number between " + Min + " and " + Max);

        guess = Random.Range(Min, Max);
        Debug.Log("is your number Higher or lower than:"  + guess);



    }
 
}
