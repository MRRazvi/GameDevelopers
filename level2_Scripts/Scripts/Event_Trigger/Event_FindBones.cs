using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event_FindBones : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text boneCount;
    public TMP_Text dialogue_txt;
    public TMP_Text obj_txt;
    public TMP_Text hint_txt;
    public AudioSource dialogue_wth;
    public AudioSource dialogue_bone_missing;
    public bool trigger = true;
    public GameObject GO;

    private void OnTriggerEnter(Collider other)
    {        
        
        if(trigger){
        StartCoroutine(waitForSec());
        GO.SetActive(true);
        trigger = false;
        }
    }


        IEnumerator waitForSec(){
        yield return new WaitForSeconds(0.5f); 
        dialogue_txt.gameObject.SetActive(true); 
        dialogue_wth.Play();
        yield return new WaitForSeconds(1.5f); 
        dialogue_bone_missing.Play();
        yield return new WaitForSeconds(2.2f); 
        dialogue_txt.gameObject.SetActive(false);
        obj_txt.SetText("Find all the bones");
        hint_txt.SetText("Hurry Up");
        boneCount.gameObject.SetActive(true);

    }
}
