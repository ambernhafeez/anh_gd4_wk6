using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    Button _difficultyButton;
    private GameManager gameManager;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // can set the on click function through script
        _difficultyButton = GetComponent<Button>();
        _difficultyButton.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        gameManager.difficulty = difficulty;
        Debug.Log("Difficulty is set to:" + difficulty);
    }
}
