using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event4 : MonoBehaviour
{    
    // Start is called before the first frame update
    public AudioSource moveRight;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;
    public TMP_Text obj;
    public bool trigger = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if(trigger){
        obj.SetText("Follow the Red Arrows !!!");
        objUpdated.SetText("Objective Updated");
        updatedSound.Play();
        anim.Play("IntroText", 0,0.0f);
        trigger = false;
        }
      
    }




}
