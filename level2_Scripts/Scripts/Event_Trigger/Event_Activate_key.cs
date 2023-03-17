using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event_Activate_key : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject key;
    public AudioSource trigger_audio;
    public TMP_Text hintText;

    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;

    void OnTriggerEnter(Collider obj){
        StartCoroutine(waitForSec());
    }

    IEnumerator waitForSec(){
        yield return new WaitForSeconds(20f);  
        key.SetActive(true);
        trigger_audio.Play();    
        hintText.SetText("Something Happened in Kitchen!!");

        objUpdated.SetText("Hint Updated");
        updatedSound.Play();
        anim.Play("IntroText", 0,0.0f);
    }
}
