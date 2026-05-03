using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    public static bool hasDaughter = false;

    void Start()
    {
        hasDaughter = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasDaughter && GameManager.Instance.HasAllNotes())
            {
                SceneLoader.LoadWin();
            }
            else if (!hasDaughter && !GameManager.Instance.HasAllNotes())
            {
                JournalUI.Instance.ShowText("I can't leave without her, and I still need to find all the notes!");
            }
            else if (!hasDaughter)
            {
                JournalUI.Instance.ShowText("I can't leave without her.");
            }
            else
            {
                JournalUI.Instance.ShowText("I need to find all the notes first...");
            }
        }
    }
}