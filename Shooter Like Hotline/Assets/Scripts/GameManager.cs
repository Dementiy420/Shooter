using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterData CharacterData;
    [SerializeField] private Text CharacterName;
    [SerializeField] private Text CharacterHealth;
    [SerializeField] private Text CountEnemies;
    [SerializeField] private int Enemies;
    private void Start()
    {
        CharacterName.text = CharacterData.Name;
        CharacterHealth.text = Convert.ToString(CharacterData.Health);
    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        CountEnemies.text = $"Enemies left: {Enemies}";
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Quit();
    }

    private void Quit() => SceneManager.LoadScene("MainMenu");
}