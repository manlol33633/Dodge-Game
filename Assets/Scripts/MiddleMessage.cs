using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiddleMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI middleMSG;
    public static bool hasWon = false;
    void Update()
    {
        if (MessageScript.numLives == 0) { middleMSG.text = "You Died!"; }
        if (hasWon) { middleMSG.text = "You Won!"; }
    }
}
