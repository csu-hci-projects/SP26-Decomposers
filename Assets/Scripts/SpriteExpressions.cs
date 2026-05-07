using UnityEngine;
using System.Collections;

public class SpriteExpressions : MonoBehaviour {


    [SerializeField] public Sprite[] freakSprites;
    [SerializeField] int neutralExpressionIndex = 0;
    [SerializeField] int negativeExpressionIndex = 1;
    [SerializeField] int positiveExpressionIndex = 2;
    private float timer = 0f;
    private bool overrideActive = false;
    private SpriteRenderer sr;



void Start() {
    sr = GetComponent<SpriteRenderer>();
    sr.sprite = freakSprites[neutralExpressionIndex];
}


void Update() {
    if (overrideActive) 
    return;
    timer += Time.deltaTime;
        if (timer >= 5f){
            timer = 0f;
            sr.sprite = freakSprites[neutralExpressionIndex];
        }
}

//Specify Expressions (negative/positive)
public void TriggerPositive(){
    StartCoroutine(ShowExpression(positiveExpressionIndex));
}
public void TriggerNegative(){
        StartCoroutine(ShowExpression(negativeExpressionIndex));
}


private IEnumerator ShowExpression(int index){
    overrideActive = true;
    sr.sprite = freakSprites[index];
    yield return new WaitForSeconds(2f);
    sr.sprite = freakSprites[neutralExpressionIndex];
    overrideActive = false;
}

}

