using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerComeInGame : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 targetPoint;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed);

        if (rb.position.y == -3.9f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
