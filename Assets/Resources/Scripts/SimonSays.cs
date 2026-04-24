using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SimonSays : MonoBehaviour
{   
    public List<int> gameRounds = new List<int>();
    public bool allowedInput = false;
    public int currentIndex = 0;

    public static void Start(){
        Random.seed = 42;
    }
    public static void newRound(){
        gameRounds.Add(Random.Range(0,4));
        allowedInput = false;
        lightUp();
        allowedInput = true;
    }

    public static void doTurn(int button){
        if (button == gameRounds[currentIndex])
    }

    public static void lightUp(){
        for(int i = 0; i < gameRounds.length; i++) {
            int light = gameRounds[i];
            //light up element
        }
    }

    public static void endGame(){
        return
    }
    
    private static MyManager _instance;
    public static MyManager instance {
        get {
            if(_instance == null)
            {
                _instance = FindObjectOfType<MyManager>(); //Only ever ran once, no prefromance issue
            }
            return _instance;
        }
    }

} 
