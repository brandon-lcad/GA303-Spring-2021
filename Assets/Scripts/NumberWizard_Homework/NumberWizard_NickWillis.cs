using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard_NickWillis : MonoBehaviour
{
    //Note that this isn't finished :/
    int PlayerHP;
    int OpponentHP;
    int OpponentMove; //1-4. 1=Punch. 2=Block. 3=Dodge Left. 4=Dodge Right.
    int RoundNumber;
    int TotalWins = 0;
    int GameMode; //Randomly assigned at start of match. 1=Player goes first; 2 = Opponent goes first.

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

       for (int RoundNumber = 0; RoundNumber < 10; RoundNumber++ ) //Game Loop until round 10
        {
            Debug.Log("Welcome to Round " + RoundNumber); //Display current round number
            OpponentMove = Random.Range(1, 4); //Generate opponent move. //1-4. 1=Punch. 2=Block. 3=Dodge Left. 4=Dodge Right.
            
            if (OpponentMove == 1 && GameMode == 1)  //When you go first (gamemode 1) and punch
            {
                Debug.Log("Your opponent throws a punch. What do you do?");
                if (Input.GetKeyDown(KeyCode.UpArrow)) //This happens if you punch
                {

                    Debug.Log("You also throw a punch and your fists collide in mid air with the sound of thunder. Nobody takes Damage. ");

                }

                else if (Input.GetKeyDown(KeyCode.DownArrow)) //This happens if you defend
                {

                    Debug.Log("You defend. Nobody takes Damage.");

                }

                else if (Input.GetKeyDown(KeyCode.LeftArrow)) //This happens if you dodge left
                {

                    Debug.Log("You dodge left. Nobody takes Damage.");

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) //This happens if you dodge right
                {

                    Debug.Log("Yopu dodge right. Nobody takes Damage.");

                }
            } 
            else if (OpponentMove == 1 && GameMode == 2)  //When opponent goes first (gamemode 2) and punches
            {
                Debug.Log("Your opponent throws a punch. What do you do?");
                if (Input.GetKeyDown(KeyCode.UpArrow)) //This happens if you punch
                {
                    
                    Debug.Log("You also throw a punch and your fists collide in mid air with the sound of thunder. Nobody takes Damage. ");

                }

                else if (Input.GetKeyDown(KeyCode.DownArrow)) //This happens if you defend
                {

                    Debug.Log("You defend. Nobody takes Damage.");

                }

                else if (Input.GetKeyDown(KeyCode.LeftArrow)) //This happens if you dodge left
                {

                    Debug.Log("You dodge left. Nobody takes Damage.");

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) //This happens if you dodge right
                {

                    Debug.Log("Yopu dodge right. Nobody takes Damage.");

                }
            } 
            else if (OpponentMove == 2 && GameMode == 1)  //When opponent goes first (gamemode 2) and blocks
            {
                Debug.Log("Your opponent throws a punch. What do you do?");
                if (Input.GetKeyDown(KeyCode.UpArrow)) //This happens if you punch
                {

                    Debug.Log("Undefined");

                }

                else if (Input.GetKeyDown(KeyCode.DownArrow)) //This happens if you defend
                {

                    Debug.Log("Undefined");

                }

                else if (Input.GetKeyDown(KeyCode.LeftArrow)) //This happens if you dodge left
                {

                    Debug.Log("Undefined");

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) //This happens if you dodge right
                {

                    Debug.Log("Undefined");

                }
            } 
            else if (OpponentMove == 3 && GameMode == 1)  //When opponent goes first (gamemode 2) and dodges left/right
            {
                Debug.Log("Your opponent throws a punch. What do you do?");
                if (Input.GetKeyDown(KeyCode.UpArrow)) //This happens if you punch
                {

                    Debug.Log("Undefined");

                }

                else if (Input.GetKeyDown(KeyCode.DownArrow)) //This happens if you defend
                {

                    Debug.Log("Undefined");

                }

                else if (Input.GetKeyDown(KeyCode.LeftArrow)) //This happens if you dodge left
                {

                    Debug.Log("Undefined");

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) //This happens if you dodge right
                {

                    Debug.Log("Undefined");

                }
            }
            
        }
    }

    void StartGame()
    {
        RoundNumber = 1;
        OpponentHP = 10;
        PlayerHP = 10;
        RoundNumber = Random.Range(1, 2);
        Debug.Log("Welcome to Punching Simuator!");
        Debug.Log("Youve Won a total of " + TotalWins + " times so far!");
        Debug.Log("Your opponent throws the first punch!");
        Debug.Log("Controls: Up arrow to attack. Down arrow to defend. Left/Right to dodge.");
        Debug.Log("What will you do?");
    }

}
