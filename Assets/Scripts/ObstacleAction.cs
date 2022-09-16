using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.position = new Vector3(-19.49f, -1.58f, 0);
            other.transform.rotation = Quaternion.Euler(0, 0, 180);
            MessageScript.numLives -= 1;
        }
    }
    void Update() {
        if (MessageScript.numLives == 0 || MiddleMessage.hasWon) {
            Time.timeScale = 0f;
        }
    }
}
