using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10; 
    public int scoreplus = 10;
    public float attackRange = 1.5f; 
    public float attackCooldown = 1f; 
    private float lastAttackTime = 0f;
    public float despawntime = 120f;

    public float moveSpeed = 2f; 
    private Transform player; 
    private bool isPlayerInRange = false;

    public float detectionRange = 20f;  
    private bool isPlayerDetected = false;

    private SpriteRenderer spriteRenderer; 
    private Color originalColor; 

    public score score;
    public AudioSource src; 
    public AudioClip hit;
    public AudioClip die;


    private Vector3 randomMoveTarget;
    public float randomMoveRadius = 2f; 
    private float randomMoveCooldown = 2f; 
    private float randomMoveTimer = 0f; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        originalColor = spriteRenderer.color; 
        
        SetRandomMoveTarget();
    }

    void Update()
    {
        despawntime -= Time.deltaTime;
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        isPlayerDetected = distanceToPlayer <= detectionRange;

        if (isPlayerDetected)
        {
            MoveTowardsPlayer();

            if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
            }
        }
        else
        {
            randomMoveTimer -= Time.deltaTime;
            if (randomMoveTimer <= 0f)
            {
                SetRandomMoveTarget();
                randomMoveTimer = randomMoveCooldown;
            }

            MoveTowardsRandomTarget();
        }

        if (despawntime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        src.clip = hit;
        src.Play();

        StartCoroutine(Flash());

        if (health <= 0)
        {
            src.clip = die;
            src.Play();
            StartCoroutine(DieEffect());
        }
    }

    void Die()
    {
        score.scoreValue += scoreplus;
        Destroy(gameObject);
    }

    void AttackPlayer()
    {
        if (player != null)
        {
            player.GetComponent<Player>().TakeDamage(damage);
        }

        lastAttackTime = Time.time;
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if (player.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void SetRandomMoveTarget()
    {
        float randomX = Random.Range(-randomMoveRadius, randomMoveRadius);
        float randomY = Random.Range(-randomMoveRadius, randomMoveRadius);
        randomMoveTarget = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);
    }

    void MoveTowardsRandomTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, randomMoveTarget, moveSpeed * Time.deltaTime);

        if (randomMoveTarget.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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
