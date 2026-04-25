using UnityEngine;
using System.Collections;


public class ButtonLogic : MonoBehaviour
{
    [SerializeField] public string color;
    [SerializeField] public int colorIndex;
    [SerializeField] public Material darkMaterial;
    [SerializeField] public Material lightMaterial;
    SimonSaysLogic manager;
    Renderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("SimonSays").GetComponent<SimonSaysLogic>();
        renderer = gameObject.GetComponent<Renderer>();
        //renderer.material = darkMaterial;
    }

    public void lightUp(){
        Debug.Log("HEYY THE BUTTON IS PRESSED");
        renderer.material = lightMaterial;
    }

    public void darken(){
        Debug.Log("HEYY THE BUTTON IS NOT PRESSED");
        renderer.material = darkMaterial;
    }

    public void press(){
        Debug.Log("AAAAAAAAAAAAAAAA");
        if(manager.allowedInput){
            Debug.Log("INPUT ALLOWED");
            lightUp();
            manager.doTurn(colorIndex);
        }
    }
    public void lightLong() {
        lightUp();
        //yield return new WaitForSeconds(2);
        Invoke("darken", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
