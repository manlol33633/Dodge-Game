using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.SetPositionAndRotation(PlayerScript.startPos, PlayerScript.startRotation);
            MessageScript.numLives -= 1;
        }
    }
    void Update() {
        if (MessageScript.numLives == 0 || MiddleMessage.hasWon) {
            Time.timeScale = 0f;
        }
        if (Input.GetKey(KeyCode.R) && MessageScript.numLives == 0) {
            MessageScript.numLives = 3;
            Time.timeScale = 1f;
            MiddleMessage.restart = true;
            PlayerScript.restart = true;
        }
    }
}
