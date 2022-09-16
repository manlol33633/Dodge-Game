using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lives;
    [SerializeField] public static int numLives = 3;
    void Update()
    {
        lives.text = "Lives: " + numLives;
    }
}
