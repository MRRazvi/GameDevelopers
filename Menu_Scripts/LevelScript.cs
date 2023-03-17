using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelScript : MonoBehaviour
{
    // public LevelManager Lm;
    // private void Start() {
    //     print(num);
    // }


    void OnTriggerEnter(Collider col)
    {
        int num= PlayerPrefs.GetInt("mylevel");
        if(col.CompareTag("level") )
        {
            PlayerPrefs.SetInt("level2", 2);
        }

        if(col.CompareTag("level2") )
        {
            PlayerPrefs.SetInt("level3", 4);
        }




    }



    void Update()
    {


        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    


}
