using System.Collections.Generic;
using UnityEngine;

public class SimonSaysLogic : MonoBehaviour
{
    public static List<int> gameRounds = new List<int>();
    public static bool allowedInput = false;
    public static int currentIndex = 0;
    public static string[] types = {"redButton", "greenButton", "blueButton", "yellowButton"};
    public static ButtonLogic[] buttons;

    public static void Start(){
        Random.InitState(42);
        buttons[0] = GameObject.Find("RedButton").GetComponent<ButtonLogic>();
        buttons[1] = GameObject.Find("GreenButton").GetComponent<ButtonLogic>();
        buttons[2] = GameObject.Find("BlueButton").GetComponent<ButtonLogic>();
        buttons[3] = GameObject.Find("YellowButton").GetComponent<ButtonLogic>();

    }
    public static void newRound(){
        gameRounds.Add(Random.Range(0,4));
        allowedInput = false;
        lightUp();
        allowedInput = true;
    }


    public static void doTurn(int button){
        if (button == gameRounds[currentIndex]) {
            Debug.Log("YOU WIN!");
        } else {
            Debug.Log("YOU LOSE!");
            allowedInput = false;
        }
    }

    public static void lightUp(){
        for(int i = 0; i < gameRounds.Count; i++) {
            int light = gameRounds[i];
            //light up element
        }
    }

    public static void endGame(){
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
