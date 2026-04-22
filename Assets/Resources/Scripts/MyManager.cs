using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class MyManager : MonoBehaviour
{   
    Random.seed = 42;
    public List<int> gameRounds = new List<int>();

    public static void newRound{
        gameRounds.Add(Random.Range(0,4))
        // lock input
        lightUp()
        // unlock input
    }

    public static void lightUp(){
        for(int i = 0; i < gameRounds.length; i++) {
            light = gameRounds[i]
            //light up element
        }
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

    

    
public void LogTrial(int trialNumber, 
                                float A,
                                float W, 
                                double trueMT, 
                                double ID,
                                double TP,
                                double origPredictedMT,
                                double shannonPredictedMT)
                                {
    string row = $"{trialNumber},{A},{W},{trueMT},{ID},{TP},{origPredictedMT},{shannonPredictedMT}";
    
    csvRows.Add(row);
                                }

public void saveCSV(){
    string header = "Trial,A,W,MT,ID,TP";
    string path = Application.dataPath + "/CsvPrint/Decomposers_Outputfile.csv";

    using (StreamWriter writer = new StreamWriter(path)){
        writer.WriteLine(header);
        foreach (string row in csvRows){
            writer.WriteLine(row);
        }
    }

    Debug.Log("CSV saved to:" + path);
}
} 
