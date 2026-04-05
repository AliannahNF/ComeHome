using UnityEngine;
using TMPro;

public class JournalUI : MonoBehaviour
{
    public static JournalUI Instance;
    public GameObject journalPanel;
    public TextMeshProUGUI journalText;

    private System.Collections.Generic.List<string> notes = new System.Collections.Generic.List<string>();

    void Awake() => Instance = this;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            journalPanel.SetActive(!journalPanel.activeSelf);
    }

    public void AddNote(string note)
    {
        if (!notes.Contains(note))
        {
            notes.Add(note);
            journalText.text = string.Join("\n\n---\n\n", notes);
        }
    }
}