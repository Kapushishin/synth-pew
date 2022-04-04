using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSystem : MonoBehaviour
{
    public float damage;
    public GameObject explosionVFX;
    public GameObject miniCircle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            gameObject.transform.localScale = new Vector2(CircleSettings.hp - damage, CircleSettings.hp - damage);
            ScoreSystem.scoreValue += 5;
            CircleSettings.hp -= damage;
            if (CircleSettings.hp < 0.5f)
            {
                Instantiate(explosionVFX, transform.position, transform.rotation);
                Destroy(gameObject);
                ScoreSystem.scoreValue += 50;
            }

            if (CircleSettings.hp > 1 && CircleSettings.hp < 1.1)
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
}
