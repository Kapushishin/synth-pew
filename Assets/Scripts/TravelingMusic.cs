using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingMusic : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
