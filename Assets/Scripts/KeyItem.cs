using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private string keyID = "daughterKey";
    [SerializeField] private GameObject pickupEffect;

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