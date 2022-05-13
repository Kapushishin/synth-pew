using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSettings : MonoBehaviour
{
    public float speed, vector, startPos;
    Rigidbody2D rb;
    bool leftBtn, rightBtn;
    public float xMin, xMax;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vector, 0f) * speed;

        rb.position = new Vector2
            (
                Mathf.Clamp(rb.position.x, xMin, xMax),
                startPos
            );
    }

    public void PointerDownLeft()
    {
        leftBtn = true;
        vector = -1.0f;
    }

    public void PointerUpLeft()
    {
        leftBtn = false;
        vector = 0f;
    }

    public void PointerDownRight()
    {
        rightBtn = true;
        vector = 1.0f;
    }

    public void PointerUpRight()
    {
        rightBtn = false;
        vector = 0f;
    }
}
