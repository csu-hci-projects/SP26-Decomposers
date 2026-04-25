using UnityEngine;
using TMPro;
using System.Collections;

public class SpriteExpressions : MonoBehaviour {


    [SerializeField] Sprite[] freakSprites;
    private int currentIndex = 0;
    private float timer = 0f;


    void Update() {
        timer += Time.deltaTime;
        if (timer >= 5f){
            timer = 0f;
            currentIndex = (currentIndex + 1) % freakSprites.Length;
            GetComponent<SpriteRenderer>().sprite = freakSprites[currentIndex];
        }
    }

}

//private Sprite newSprite;
//newSprite = freakSprites[Random.Range(0, freakSprites.Length)];
        //gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;