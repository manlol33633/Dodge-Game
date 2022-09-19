using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private Vector3 startPos = new Vector3(-15.75f, -3.13f, 0);
    [SerializeField] private Vector3 endPos = new Vector3(-12.92f, -3.13f, 0);
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotSpeed = 720;
    private int currentCorner = 0;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.position = new Vector3(-19.49f, -1.58f, 0);
            other.transform.rotation = Quaternion.Euler(0, 0, 180);
            MessageScript.numLives -= 1;
        }
    }
    void Start()
    {
        transform.position = startPos;
    }
    void Update()
    {
        if (transform.position == startPos) { currentCorner = 0; }
        if (transform.position == endPos) { currentCorner = 1; }
        if (currentCorner == 0) { transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime); }
        if (currentCorner == 1) { transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime); }
        if (MessageScript.numLives == 0 || MiddleMessage.hasWon) {
            Time.timeScale = 0f;
        }
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
