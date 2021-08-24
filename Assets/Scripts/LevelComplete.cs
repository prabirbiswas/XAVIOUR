using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public static bool GameIsStop = false;
    [SerializeField] private GameObject levelcomplteUI;


    private void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            levelcomplteUI.SetActive(true);
            Cursor.visible =true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            GameIsStop = true;
        }
       
    }
     public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting the Game");
        Application.Quit();
    }
    public void nextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void saveData()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
