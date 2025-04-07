using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text CharacterName;
    [SerializeField] private Text CharacterHealth;
    [SerializeField] private Text CountEnemies;
    [SerializeField] private int Enemies;
    
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        CountEnemies.text = $"Enemies left: {Enemies}";
        
        if (Enemies == 0)
            CountEnemies.text = "You Win!";
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Quit();
    }

    private void Quit() => SceneManager.LoadScene("MainMenu");
}