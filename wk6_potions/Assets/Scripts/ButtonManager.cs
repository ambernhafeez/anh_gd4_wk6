using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject difficultyMenu;
    public GameObject optionsMenu;
    public Slider _volumeSlider;
    public Slider _sfxSlider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        optionsMenu.SetActive(true);
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

    // options menu sliders
    public void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", _volumeSlider.value);
    }

    public void LoadVolume()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

}
