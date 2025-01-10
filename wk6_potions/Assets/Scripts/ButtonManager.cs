using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject difficultyMenu;
    public GameObject optionsMenu;
    public Slider _volumeSlider;
    //public AudioListener audioListener;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //audioListener.GetComponent<AudioListener>();
        
        difficultyMenu.SetActive(false);
        optionsMenu.SetActive(false);

        // load volume player prefs
        if(!PlayerPrefs.HasKey("MusicVolume"))
        {
            // if no music volume set, set music volume to default
            PlayerPrefs.SetFloat("MusicVolume", 0.8f);
            LoadVolume();
        }
        else{ LoadVolume(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        Time.timeScale = 0f; 
        optionsMenu.SetActive(true);
    }

    public void OpenDifficulty()
    {
        difficultyMenu.SetActive(true);
    }

    public void BackButtonOptions()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void BackButtonDifficulty()
    {
        difficultyMenu.SetActive(false);
    }

    // options menu sliders
    public void ChangeVolume()
    {
        Debug.Log("Change volume function called! Volume: " + AudioListener.volume);
        AudioListener.volume = _volumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", _volumeSlider.value);
        Debug.Log("Player prefs volume: " + PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void LoadVolume()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

}
