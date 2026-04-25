using UnityEngine;
using TMPro;
using System.Collections;

public class AudienceMovement : MonoBehaviour {

    public float bounceHeight = 0.2f;
    public float bounceSpeed = 1.8f;

    private Vector3 startPosition;

    void Start(){
        startPosition = transform.position;
    }

    void Update(){
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}