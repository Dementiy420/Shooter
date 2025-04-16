using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Stats stats;
    [SerializeField] private CharactersDataBase charac;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    
    public void QuitGame() => Application.Quit();
    
    public void QuitToMainMenu() => SceneManager.LoadScene("MainMenu");

    public void SetOswald()
    {
        PlayerPrefs.SetInt("Character", 0);
        int i = PlayerPrefs.GetInt("Character");
        Debug.Log(i);
    }

    public void SetRobert()
    {
        PlayerPrefs.SetInt("Character", 1);
        int i = PlayerPrefs.GetInt("Character");
        Debug.Log(i);
    }

    public void SetSeiko()
    {
        PlayerPrefs.SetInt("Character", 2);
        int i = PlayerPrefs.GetInt("Character");
        Debug.Log(i);
    }
}