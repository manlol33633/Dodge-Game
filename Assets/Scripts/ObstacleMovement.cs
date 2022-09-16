using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 20;
    private Color transparent = new Vector4(255, 255, 255, 0);
    private Color opaque = new Vector4(255, 255, 255, 255);
    [SerializeField] private Quaternion startRotation = Quaternion.Euler(0, 0, 180);
    [SerializeField] private Quaternion secondRotation = Quaternion.Euler(0, 0, 90);
    [SerializeField] private Quaternion thirdRotation = Quaternion.Euler(0, 0, 0);
    [SerializeField] private Quaternion fourthRotation = Quaternion.Euler(0, 0, -90);
    [SerializeField] private Vector3 startCorner = new Vector3(-15.58f, -1.21f, 0);
    [SerializeField] private Vector3 firstCorner = new Vector3(-4.63f, -1.21f, 0);
    [SerializeField] private Vector3 secondCorner = new Vector3(-4.63f, -8.61f, 0);
    [SerializeField] private Vector3 thirdCorner = new Vector3(-16.41f, -8.61f, 0);
    [SerializeField] private Vector3 fourthCorner = new Vector3(-16.41f, -3.02f, 0);
    private int positionCorner;
    private int rotationCorner;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.position = new Vector3(-19.49f, -1.58f, 0);
            other.transform.rotation = Quaternion.Euler(0, 0, 180);
            MessageScript.numLives -= 1;
        }
    }
    void Start() {
        transform.SetPositionAndRotation(startCorner, startRotation);
    }
    void Update() {
        if (transform.position == startCorner) { rotationCorner = 0; }
        if (transform.position == firstCorner) { rotationCorner = 1; }
        if (transform.position == secondCorner) { rotationCorner = 2; }
        if (transform.position == thirdCorner) { rotationCorner = 3; }
        if (transform.position == fourthCorner) { rotationCorner = 4; }
        if (transform.position == startCorner) { positionCorner = 0; }
        if (transform.position == firstCorner) { positionCorner = 1; }
        if (transform.position == secondCorner) { positionCorner = 2; }
        if (transform.position == thirdCorner) { positionCorner = 3; }
        if (transform.position == fourthCorner) { positionCorner = 4; }
        if (rotationCorner == 0) { transform.rotation = Quaternion.RotateTowards(transform.rotation, startRotation, rotationSpeed * Time.deltaTime); }
        if (rotationCorner == 1) { transform.rotation = Quaternion.RotateTowards(transform.rotation, secondRotation, rotationSpeed * Time.deltaTime); }
        if (rotationCorner == 2) { transform.rotation = Quaternion.RotateTowards(transform.rotation, thirdRotation, rotationSpeed * Time.deltaTime); }
        if (rotationCorner == 3) { transform.rotation = Quaternion.RotateTowards(transform.rotation, fourthRotation, rotationSpeed * Time.deltaTime); }
        if (positionCorner == 0) { transform.position = Vector3.MoveTowards(transform.position, firstCorner, speed * Time.deltaTime); }
        if (positionCorner == 1 && transform.rotation == secondRotation) { transform.position = Vector3.MoveTowards(transform.position, secondCorner, speed * Time.deltaTime); }
        if (positionCorner == 2 && transform.rotation == thirdRotation) { transform.position = Vector3.MoveTowards(transform.position, thirdCorner, speed * Time.deltaTime); }
        if (positionCorner == 3 && transform.rotation == fourthRotation) { transform.position = Vector3.MoveTowards(transform.position, fourthCorner, speed * Time.deltaTime); }
        if (positionCorner == 4 && rotationCorner == 4) {
            transform.SetPositionAndRotation(startCorner, startRotation);
        }
        if (MessageScript.numLives == 0 || MiddleMessage.hasWon) {
            Time.timeScale = 0f;
        }
    }
}