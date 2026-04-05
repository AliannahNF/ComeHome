using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadGameOver() => SceneManager.LoadScene("GameOver");
    public static void LoadWin()      => SceneManager.LoadScene("WinScene");
    public static void LoadGame()     => SceneManager.LoadScene("GameScene");
    public static void Quit()         => Application.Quit();
}