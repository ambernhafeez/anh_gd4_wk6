using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    public bool isGameOver, isPaused; 
    public TMP_Text scoreText;

    [Header("User interface")]
    // game over UI 
    public GameObject gameOverScreen, newHighScoreText;
    public TMP_Text scoreTextGameOver, highScoreText;
    // the score and lives in-game UI
    public GameObject HUD;
    public int score, lives;
    // pause screen UI
    public GameObject pauseScreen;

    //options menu
    public GameObject optionsMenu;

    // life system
    public GameObject[] potions;
    
    // difficulty
    public int difficulty;
    Vector2 spawnRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnObjects());
        gameOverScreen.SetActive(false);
        HUD.SetActive(true);
        newHighScoreText.SetActive(false);
        pauseScreen.SetActive(false);
        optionsMenu.SetActive(false);
        lives = potions.Length;

        // set spawnRate based on difficulty
        difficulty = PlayerPrefs.GetInt("Difficulty");
        if(difficulty == 1){spawnRate = new Vector2(0.6f, 2); }
        else if(difficulty == 2){spawnRate = new Vector2(0.3f, 1.5f); }
        else if(difficulty == 3){spawnRate = new Vector2(0.1f, 1f); }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnObjects()
    {
        while(!isGameOver && !isPaused)
        {
            Time.timeScale = 1f; 
            yield return new WaitForSeconds(1);
            // pick a random object to spawn 
            int spawnIndex = Random.Range(0, targets.Count);
            // spawn object
            Instantiate(targets[spawnIndex]);
            // wait for seconds
            float randomWaitTime = Random.Range(spawnRate.x, spawnRate.y);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }

    public void UpdateScore(int scoreChange, int livesChange)
    {
        score += scoreChange;
        scoreText.text = "" + score;

        if(lives >= 1)
        {
            lives += livesChange;
            Destroy(potions[lives].gameObject);
        }
        if(lives <= 0){GameOverState(); }

    }

    void GameOverState()
    {
        scoreTextGameOver.text = "SCORE: " + score;
        // show previous high score
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
        isGameOver = true;
        HUD.SetActive(false);
        gameOverScreen.SetActive(true);

        // set a new highscore if player beats it
        if(PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            // indicator of new high score - graphic or text?
            newHighScoreText.SetActive(true);
        }
    }

    // this function will be accessed by the restart UI button
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    // for menu button on game over overlay
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    // pause button
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 
        pauseScreen.SetActive(true);
    }

    // resume game
    public void ResumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        optionsMenu.SetActive(false);
        StartCoroutine(spawnObjects());
    }

    // options overlay button function
    public void OpenOptions()
    {
        isPaused = true;
        Time.timeScale = 0f; 
        optionsMenu.SetActive(true);
    }

    // slicing action
    // if mouse is pressed isSlicing == true
    // if mouse is released isSlicing == false
    // 

}
