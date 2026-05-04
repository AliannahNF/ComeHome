using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private string keyID = "daughterKey";
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            int random = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[random].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey(keyID);

            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
        }
    }
}