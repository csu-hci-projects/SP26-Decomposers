using System.Collections.Generic;
using UnityEngine;

public class SimonSaysLogic : MonoBehaviour
{
    public static List<int> gameRounds = new List<int>();
    public bool allowedInput = true;
    public static int currentIndex = 0;
    public static string[] types = {"redButton", "greenButton", "blueButton", "yellowButton"};
    public static ButtonLogic[] buttons;

    public void Start(){
        Random.InitState(42);
        buttons[0] = GameObject.Find("RedButton").GetComponent<ButtonLogic>();
        buttons[1] = GameObject.Find("GreenButton").GetComponent<ButtonLogic>();
        buttons[2] = GameObject.Find("BlueButton").GetComponent<ButtonLogic>();
        buttons[3] = GameObject.Find("YellowButton").GetComponent<ButtonLogic>();
        gameRounds.Add(0);
        gameRounds.Add(1);
        gameRounds.Add(2);
        gameRounds.Add(3);
        newRound();
        //allowedInput = true;
    }
    public void newRound(){
        gameRounds.Add(Random.Range(0,4));
        //allowedInput = false;
        runThroughLights();
        //allowedInput = true;
    }


    public void doTurn(int button){
        if (button == gameRounds[currentIndex]) {
            Debug.Log("YOU WIN!");
            newRound();
        } else {
            Debug.Log("YOU LOSE!");
            //allowedInput = false;
        }
    }

    public void runThroughLights(){
        for(int i = 0; i < gameRounds.Count; i++) {
            int light = gameRounds[i];
            buttons[light].lightLong();
            //light up element
        }
    }

    public void endGame(){
        return;
    }
    
    private static SimonSaysLogic _instance;
    public static SimonSaysLogic instance {
        get {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SimonSaysLogic>(); //Only ever ran once, no prefromance issue
            }
            return _instance;
        }
    }
}
