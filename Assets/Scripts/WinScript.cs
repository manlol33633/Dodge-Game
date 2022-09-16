using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        MiddleMessage.hasWon = true;
    }
    void Update() {
        if (Input.GetKey(KeyCode.R) && MessageScript.numLives == 0) {
            MessageScript.numLives = 3;
            PlayerScript.obj.timeScale = 1f;
        }
        if (Input.GetKey(KeyCode.R) && MiddleMessage.hasWon) {
            MiddleMessage.hasWon = false;
            PlayerScript.obj.timeScale = 1f;
        }
    }
}