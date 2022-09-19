using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            MiddleMessage.hasWon = true;
        }
    }
    void Update() {
        if (Input.GetKey(KeyCode.R) && MiddleMessage.hasWon) {
            MiddleMessage.hasWon = false;
            Time.timeScale = 1f;
            MiddleMessage.restart = true;
            PlayerScript.restart = true;
        }
    }
}