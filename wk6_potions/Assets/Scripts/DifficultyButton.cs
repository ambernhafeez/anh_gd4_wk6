using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    Button _difficultyButton;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // can set the on click function through script
        _difficultyButton = GetComponent<Button>();
        _difficultyButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
        Debug.Log("Difficulty is set to:" + difficulty);
    }
}
