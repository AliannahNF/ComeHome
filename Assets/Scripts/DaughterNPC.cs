using UnityEngine;

public class DaughterNPC : MonoBehaviour
{
    private bool found = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !found)
        {
            found = true;
            EscapeTrigger.hasDaughter = true;
            Debug.Log("You found her.");
        }
    }
}