using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    public static bool hasDaughter = false;

    void Start()
    {
        hasDaughter = false; // reset each time scene loads
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasDaughter)
            {
                SceneLoader.LoadWin();
            }
            else
            {
                Debug.Log("You need to find the daughter first!");
            }
        }
    }
}