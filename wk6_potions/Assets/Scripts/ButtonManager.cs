using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject difficultyMenu;
    public GameObject optionsMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficultyMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        StartGame();
    }

    public void OpenSettings()
    {
        Debug.Log("Settings!");
    }

    public void OpenDifficulty()
    {
        difficultyMenu.SetActive(true);
    }

    public void BackButtonOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void BackButtonDifficulty()
    {
        difficultyMenu.SetActive(false);
    }
}
