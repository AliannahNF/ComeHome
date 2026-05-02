using UnityEngine;

public class MotherAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float detectionRange = 50f;
    public int damageAmount = 20;
    public float minSpawnDistanceFromPlayer = 10f;
    public Transform[] spawnPoints;

    private float damageCooldown = 1f;
    private float lastDamageTime;
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        SpawnAtPoint();
    }

    void SpawnAtPoint()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to MotherAI!");
            return;
        }

        Transform chosen = spawnPoints[Random.Range(0, spawnPoints.Length)];
        int attempts = 0;

        while (Vector2.Distance(chosen.position, player.position) < minSpawnDistanceFromPlayer && attempts < 20)
        {
            chosen = spawnPoints[Random.Range(0, spawnPoints.Length)];
            attempts++;
        }

        transform.position = chosen.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
            ChasePlayer();
        else
            rb.linearVelocity = Vector2.zero;
    }

    void ChasePlayer()
    {
        Vector2 direction = ((Vector2)player.position - rb.position).normalized;
        rb.linearVelocity = direction * chaseSpeed;
        UpdateAnimation(direction);
    }

    void UpdateAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
                animator.Play("Mom_Walk_Right");
            else
                animator.Play("Mom_Walk_Left");
        }
        else
        {
            if (direction.y > 0)
                animator.Play("Mom_Walk_Up");
            else
                animator.Play("Mom_Walk_Down");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > lastDamageTime + damageCooldown)
            {
                playerHealth.TakeDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}
