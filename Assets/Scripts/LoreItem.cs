using UnityEngine;
using TMPro;

public class LoreItem : MonoBehaviour
{
    [TextArea]
    public string loreText = "She tried to leave today. I can't let that happen.";
    
    public GameObject textPanel;
    public TextMeshProUGUI textDisplay;
    
    private bool playerInRange = false;
    private bool hasBeenRead = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            textPanel.SetActive(!textPanel.activeSelf);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            textPanel.SetActive(true);
            textDisplay.text = loreText;

            if (JournalUI.Instance != null)
                JournalUI.Instance.AddNote(loreText);

            if (!hasBeenRead)
            {
                hasBeenRead = true;
                GameManager.Instance.totalNotesCollected++;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            textPanel.SetActive(false);
        }
    }
}