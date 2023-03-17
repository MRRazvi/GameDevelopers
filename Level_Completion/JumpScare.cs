using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpScare : MonoBehaviour
{
    public TMP_Text Whisper_txt;
    public GameObject Slender;
    public Animator camera_anim;
    public AudioSource WhatWasThat;
    public AudioSource checkSound;
    public bool triggers = true;
    public Notes notes_obj;

    // Start is called before the first frame update
    void Start()
    {
        Slender.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter()
    { 
        if(triggers){
        camera_anim.enabled = true;
        camera_anim.Play("camera_anim2",0,0.0f);
        Slender.SetActive(true);
        StartCoroutine(EndJump());
        notes_obj.evidenceScore ++;
        notes_obj.evidenceCount.text = "" + notes_obj.evidenceScore;
        triggers= false;
        }

    }

    IEnumerator EndJump()
    {   
        yield return new WaitForSeconds(2.0f);
        camera_anim.enabled = false;
        Slender.SetActive(false);
        WhatWasThat.Play();
        yield return new WaitForSeconds(3.0f);
        // Destroy(gameObject);
        Whisper_txt.gameObject.SetActive(true);
        checkSound.Play();

        // yield return new WaitForSeconds(7.0f);

    }
}
