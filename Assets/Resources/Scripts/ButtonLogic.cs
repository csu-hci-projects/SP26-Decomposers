using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonLogic : MonoBehaviour
{
    [SerializeField] public string color;
    [SerializeField] public int colorIndex;
    [SerializeField] public Material darkMaterial;
    [SerializeField] public Material lightMaterial;
    SimonSaysLogic manager;
    Renderer renderer;
    SpriteExpressions spriteExpressions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("SimonSays").GetComponent<SimonSaysLogic>();
        renderer = gameObject.GetComponent<Renderer>();
        //renderer.material = darkMaterial;

    //Sprite expression stuff
        spriteExpressions = FindObjectOfType<SpriteExpressions>();
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(OnGrabbed);
    }

    public void lightUp(){
        renderer.material = lightMaterial;
    }

    public void darken(){
        renderer.material = darkMaterial;
    }

    public void test(){
        manager.runThroughLights();
    }

    public void press(){
        if(!manager.started){
            manager.newRound();
            manager.started = true;
            lightLong();
        }else if(manager.allowedInput){
            lightLong();
            manager.doTurn(colorIndex);
        }
    }
    public void lightLong() {
        lightUp();
        //yield return new WaitForSeconds(2);
        Invoke("darken", 0.5f);
    }

//Correct Clicks for Sprite Expressions
void OnDestroy(){
    var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
    if (interactable != null)
        interactable.selectEntered.RemoveListener(OnGrabbed);
}
private void OnGrabbed(SelectEnterEventArgs args){
    if (!SimonSaysLogic.allowedInput) 
        return;
    bool isCorrect = colorIndex == SimonSaysLogic.gameRounds[SimonSaysLogic.currentIndex];
    if (isCorrect){
        spriteExpressions.TriggerPositive();
    } else {
        spriteExpressions.TriggerNegative();
    }

    press();
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
