using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Levelpanel;
    [SerializeField] GameObject Menupanel;
    [SerializeField] GameObject Settingspanel;
    [SerializeField] GameObject MuteBotton;
    [SerializeField] GameObject UnmuteBotton;
    public AudioSource clickSound;

    public void Start()
    {
         clickSound.Play();
        Menupanel.SetActive(true);
        Levelpanel.SetActive(false);
        Settingspanel.SetActive(false);
    }

    // Update is called once per frame
    public void NewGame()
    {
        clickSound.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Hospital_Scene");
    }

    public void EndGame()
    {
         clickSound.Play();
        Application.Quit();
    }

    public void Level()
    {
        clickSound.Play();
        Menupanel.SetActive(false);
        Levelpanel.SetActive(true);
    }

    public void Setting()
    {
        clickSound.Play();
        Menupanel.SetActive(false);
        Levelpanel.SetActive(false);
        Settingspanel.SetActive(true);
        MuteBotton.SetActive(true);
        UnmuteBotton.SetActive(false);
    }

    public void Mute()
    {
        AudioListener.volume = 0;
        MuteBotton.SetActive(false);
        UnmuteBotton.SetActive(true);
    }

    public void Unmute()
    {
        clickSound.Play();
        AudioListener.volume = 1;
        UnmuteBotton.SetActive(false);
        MuteBotton.SetActive(true);
    }
}
