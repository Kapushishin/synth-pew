using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxOfHearts;

    public int damage;

    public Image[] healths;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator camShake;

    public GameObject explosionPlayerVFX;
    public GameObject deathMenu;

    void Update()
    {
        if (currentHealth > maxOfHearts)
        {
            currentHealth = maxOfHearts;
        }

        for (int i = 0; i < healths.Length; i++)
        {
            if (i < currentHealth)
            {
                healths[i].sprite = fullHeart;
            }
            else
            {
                healths[i].sprite = emptyHeart;
            }


            if (i < maxOfHearts)
            {
                healths[i].enabled = true;
            }

            else
            {
                healths[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= damage;
            Shake();

            if (currentHealth <= 0)
            {
                healths[0].sprite = emptyHeart;
                Instantiate(explosionPlayerVFX, transform.position, transform.rotation);
                Destroy(gameObject);
                deathMenu.SetActive(true);
            }
        }
    }

    public void Shake()
    {
        camShake.SetTrigger("ShakeTrigger");
    }
}
