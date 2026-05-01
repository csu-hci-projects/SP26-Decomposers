using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SimonSaysLogic : MonoBehaviour
{
    public List<int> gameRounds;
    public bool started;
    public bool allowedInput;
    public int currentRound;
    public static ButtonLogic[] buttons = new ButtonLogic[4];
    

    public void Start(){
        buttons[0] = GameObject.Find("RedButton").GetComponent<ButtonLogic>();
        buttons[1] = GameObject.Find("GreenButton").GetComponent<ButtonLogic>();
        buttons[2] = GameObject.Find("BlueButton").GetComponent<ButtonLogic>();
        buttons[3] = GameObject.Find("YellowButton").GetComponent<ButtonLogic>();
        initializeGame(42);
    }

    public void initializeGame(int seed){
        Random.InitState(seed);
        gameRounds = new List<int>();
        started = false;
        allowedInput = true;
        currentRound = 0;
    }

    public void newRound(){
        currentRound = 0;
        gameRounds.Add(Random.Range(0,4));
        runThroughLights();
    }

    public void doTurn(int button){
        Debug.Log(button);
        if (button == gameRounds[currentRound]) {
            currentRound += 1;
        } else {
            endGame();
        }
        if (currentRound >= gameRounds.Count){
            newRound();
        }
    }

    public void runThroughLights(){
        StartCoroutine(lightHelper());
    }

    IEnumerator lightHelper(){
        allowedInput = false;
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < gameRounds.Count; i++) {
            Debug.Log(i);
            int light = gameRounds[i];
            buttons[light].lightUp();
            yield return new WaitForSeconds(0.5f);
            buttons[light].darken();
            yield return new WaitForSeconds(0.5f);
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
                _instance = Object.FindFirstObjectByType<SimonSaysLogic>(); //Only ever ran once, no prefromance issue
            }
            return _instance;
        }
    }
}
