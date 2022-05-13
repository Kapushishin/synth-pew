using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSettings : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 _direction;
    public float speed;

    public float hp;
    public float damage;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public GameObject explosionVFX;
    public GameObject explosionSFX;
    public GameObject miniCircle;

    void Start()
    {
        _direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0.0f));
        rb.AddForce(_direction * speed, ForceMode2D.Impulse);
        hp = Random.Range(0.5f, 1.5f);
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
            ScaleTranform();
            ScoreSystem.scoreValue += 5;
            hp -= damage;
            if (hp < 0.5f)
            {
                EnemyDestroing();
            }

            if (hp > 1 && hp < 1.1)
            {
                Instantiate(explosionVFX, gameObject.transform.position, Quaternion.identity);
                Instantiate(miniCircle, gameObject.transform.position, Quaternion.identity);
                Instantiate(miniCircle, gameObject.transform.position, Quaternion.identity);
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

    void ScaleTranform()
    {
        gameObject.transform.localScale = new Vector2(hp - damage, hp - damage);
    }

    void EnemyDestroing()
    {
        Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(gameObject);
        ScoreSystem.scoreValue += 50;
    }

    /*public static void Destr(GameObject circle)
    {
        Destroy(circle);
        ScoreSystem.scoreValue += 50;
    }*/

    void RandomSprite()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
