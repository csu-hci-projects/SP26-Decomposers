using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SimonSaysLogic : MonoBehaviour
{
    public List<int> gameRounds = new List<int>();
    public bool allowedInput = false;
    public int currentIndex = 0;
    public int lightUpIndex = 0;
    public static string[] types = {"redButton", "greenButton", "blueButton", "yellowButton"};
    public static ButtonLogic[] buttons = new ButtonLogic[4];
    public bool started = false;

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
        Debug.Log("SUCCESS!!!!!");
    }
    public void newRound(){
        currentIndex = 0;
        gameRounds.Add(Random.Range(0,4));
        runThroughLights();
        Debug.Log("NEW ROUND  :" + gameRounds[gameRounds.Count - 1]);
    }


    public void doTurn(int button){
        Debug.Log("BUTTON PRESS: " + gameRounds[currentIndex] + " " + button);
        Debug.Log(button);
        if (button == gameRounds[currentIndex]) {
            Debug.Log("YOU WIN!");
            currentIndex += 1;
        } else {
            Debug.Log("YOU LOSE!");
        }
        if (currentIndex >= gameRounds.Count){
            newRound();
        }
    }

    public void runThroughLights(){
        Debug.Log("RUNNING THROUGH LIGHTS");
        StartCoroutine(lightHelper());
    }

    IEnumerator lightHelper(){
        allowedInput = false;
        yield return new WaitForSeconds(1);
        Debug.Log("LIGHT HELPER");
        Debug.Log(gameRounds.Count);
        for(int i = 0; i < gameRounds.Count; i++) {
            Debug.Log(i);
            int light = gameRounds[i];
            buttons[light].lightUp();
            yield return new WaitForSeconds(0.5f);
            buttons[light].darken();
            yield return new WaitForSeconds(0.5f);
            //light up element
        }
        allowedInput = true;
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
