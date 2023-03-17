using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompetedScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NotesRayCast nr = null;
    [SerializeField] private Score sr = null;
    public GameObject go;
    public GameObject completeAllObj;
    // && nr.evidenceScore==3 && sr.currentScore==12
    public void OnTriggerEnter(Collider other){
            if(other.gameObject.name =="First Person Controller Minimal" && nr.evidenceScore==3 && sr.currentScore==12 ){
            //    SceneManager.LoadScene("MainStory");
            
            go.SetActive(true);
            }
            else {
                completeAllObj.SetActive(true);
            }
    }

        public void OnTriggerExit(Collider other){
            go.SetActive(false);
            completeAllObj.SetActive(false);
            
    }


}
