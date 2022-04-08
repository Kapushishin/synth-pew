using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCircleSettings : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 direction;
    public float speed;

    public float hp;
    public float damage;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public GameObject explosionVFX;
    public GameObject explosionSFX;

    void Start()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0.0f));
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        gameObject.transform.localScale = new Vector2(hp, hp);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        RandomSprite();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            gameObject.transform.localScale = new Vector2(hp - damage, hp - damage);
            ScoreSystem.scoreValue += 5;
            hp -= damage;
            if (hp < 0.5f)
            {
                Instantiate(explosionVFX, transform.position, transform.rotation);
                Destroy(gameObject);
                ScoreSystem.scoreValue += 50;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void RandomSprite()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
