using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool hasDaughter = false;
    public int totalNotesCollected = 0;

    private List<string> collectedKeys = new List<string>();

    void Awake() => Instance = this;

    public void CollectKey(string keyID)
    {
        if (!collectedKeys.Contains(keyID))
            collectedKeys.Add(keyID);
    }

    public bool HasKey(string keyID)
    {
        return collectedKeys.Contains(keyID);
    }

    public bool HasAllNotes()
    {
        return totalNotesCollected >= 5;
    }
}