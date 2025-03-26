using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("SampleScene");
    

    public void QuitGame() => Application.Quit();
    
    
    public void QuitToMainMenu() => SceneManager.LoadScene("MainMenu");
}