using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Event8 : MonoBehaviour
{
    public GameObject AIMonster;
    public TMP_Text obj;
    public TMP_Text hint;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;
   
    public bool trigger= true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void OnTriggerEnter(Collider other){
        if(trigger){
        AIMonster.SetActive(true);
        obj.SetText("Run & Escape");
        hint.SetText("Don't Look Back !!!");
        objUpdated.SetText("Objective Updated");
        updatedSound.Play();
        anim.Play("IntroText", 0,0.0f);
        trigger= false;
        }
    }




}
