using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameOverManager GameOverManager;
    private SpriteRenderer spriteRenderer; 
    private Color originalColor; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        originalColor = spriteRenderer.color; 
    }

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Flash()); 
        if (health <= 0)
        {
            StartCoroutine(DieEffect());
            GameOverManager.triggerOverlay();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator Flash()
    {
        spriteRenderer.color = Color.gray;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = originalColor;
    }

    IEnumerator DieEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Die();
    }
}
