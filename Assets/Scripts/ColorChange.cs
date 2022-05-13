using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    Image image;
    Color colorGray;
    void Start()
    {
        image = GetComponent<Image>();
        //colorGray = new Color(0.4f, 0.4f, 0.4f);
    }

    private void Update()
    {
        image.color = Color.Lerp(Color.black, Color.white, Time.time / 3);
    }
}
