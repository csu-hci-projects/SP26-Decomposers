using UnityEngine;
using TMPro;
using System.Collections;

public class AudienceMovement : MonoBehaviour {

    public float bounceHeight = 0.5f;
    public float bounceSpeed = 2f;

    private Vector3 startPosition;

    void Start(){
        startPosition = transform.position;
    }

    void Update(){
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}