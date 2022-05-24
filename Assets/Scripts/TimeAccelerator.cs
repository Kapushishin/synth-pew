using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAccelerator : MonoBehaviour
{
    private int i = 300;

    private void Update()
    {
        if (ScoreSystem.scoreValue >= i - 50 && ScoreSystem.scoreValue <= i + 50)
        {
            i += 300;
            Time.timeScale = Time.timeScale + 0.015f;
        }
    }
}
