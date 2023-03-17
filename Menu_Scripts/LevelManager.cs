using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    int tempSave;
    bool check;
    public Button level_2; 
    public Button level_3; 


    public void LevelOneButton(){
    Time.timeScale = 1.0f;
    SceneManager.LoadScene(6);
    }


    public void Level2Button(){
      Time.timeScale = 1.0f;
    SceneManager.LoadScene(9);
    }


    
    public void Level3Button(){
      Time.timeScale = 1.0f;
    SceneManager.LoadScene(12);
    }


    void Update(){
       if(PlayerPrefs.GetInt("level2")==2){
       level_2.gameObject.SetActive(true);
       }

    if(PlayerPrefs.GetInt("level3")==4){
       level_3.gameObject.SetActive(true);
       }


    }
}
