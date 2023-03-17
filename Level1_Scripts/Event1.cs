using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// public TMP_Text hint_txt;

public class Event1 : MonoBehaviour

{
public TMP_Text obj_txt;
public TMP_Text objUpdated;
public AudioSource updatedSound;
public GameObject Creature;
public Animator anim;
public bool trigger= true;
    // // Start is called before the first frame update
    void Start()
    {
          
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

     private void OnTriggerEnter(Collider other) {

        // objUpdated.SetText("Objective Updated");
        // updatedSound.Play();
        // anim.Play("IntroText", 0,0.0f);
        if(trigger){
        StartCoroutine(waitForSec()); 
        Creature.SetActive(true);
        trigger= false;
        // Destroy(gameObject);
        } 
        
    }

    IEnumerator waitForSec(){
        yield return new WaitForSeconds(1.7f);
        Creature.SetActive(false);
        // yield return new WaitForSeconds(1.8f);
        objUpdated.SetText("Objective Updated");
        obj_txt.SetText("Explore the house !!");
        updatedSound.Play();
        anim.Play("IntroText", 0,0.0f);
        
    }





}
