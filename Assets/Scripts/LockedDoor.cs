using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private string requiredKeyID = "daughterKey";
    [SerializeField] private GameObject doorObject;
    [SerializeField] private string lockedMessage = "It's locked. There must be a key somewhere...";
    [SerializeField] private string unlockedMessage = "The door swings open.";

    private bool isUnlocked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (isUnlocked) return;

        if (GameManager.Instance.HasKey(requiredKeyID))
            UnlockDoor();
        else
            JournalUI.Instance.ShowText(lockedMessage);
    }

    private void UnlockDoor()
    {
        isUnlocked = true;
        JournalUI.Instance.ShowText(unlockedMessage);

        if (doorObject != null)
            doorObject.SetActive(false);

        foreach (var col in GetComponents<Collider2D>())
            col.enabled = false;
    }
}