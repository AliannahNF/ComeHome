using UnityEngine;

public class MotherAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float detectionRange = 8f;
    public int damageAmount = 20;
    
    private float damageCooldown = 1f;
    private float lastDamageTime;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
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