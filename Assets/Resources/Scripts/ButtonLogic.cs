using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonLogic : MonoBehaviour
{
    [SerializeField] public string color;
    [SerializeField] public int colorIndex;
    [SerializeField] public Material darkMaterial;
    [SerializeField] public Material lightMaterial;
    [SerializeField] public Material selectMaterial;
    SimonSaysLogic manager;
    Renderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("SimonSays").GetComponent<SimonSaysLogic>();
        renderer = gameObject.GetComponent<Renderer>();
    }

    public void lightUp(){
        renderer.material = lightMaterial;
    }

    public void darken(){
        renderer.material = darkMaterial;
    }

    public void select(){
        renderer.material = selectMaterial;
    }

    public void press(){
        if(!manager.started){
            manager.newRound();
            manager.started = true;
            selectLong();
        }else if(manager.allowedInput){
            lightLong();
            manager.doTurn(colorIndex);
        }
    }
    public void lightLong() {
        lightUp();
        Invoke("darken", 0.5f);
    }

    public void selectLong() {
        select();
        Invoke("darken", 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
