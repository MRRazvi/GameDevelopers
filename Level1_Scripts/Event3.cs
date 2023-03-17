using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event3 : MonoBehaviour
{
    public GameObject eventTrigger;
    public bool pauseEve= true;
    public TMP_Text timer;
    public int currentScore;
    private bool takingAway= false;
    public GameObject player;
    public AudioSource ticking;
    public AudioSource Drink;
    public Animator camera_anim;
    public GameObject Slender;
    public TMP_Text eve_txt;
    public AudioSource checkSound;
    public Notes notes_obj;

    // Start is called before the first frame update
    void Start()
    {
        currentScore=30;
        if(pauseEve){
            StartCoroutine(PauseEvent());
        }
            //  timer.text = "00" + currentScore;
    }

    // // Update is called once per frame
    void Update()
    {
 
       if(takingAway== false && currentScore>0){
        StartCoroutine(TimeTaken());
       } 
    }


    void OnTriggerEnter(Collider collision)
    {
    Drink.Play();
    eve_txt.gameObject.SetActive(true);
    checkSound.Play();
    StartCoroutine(waitSec());
  
    }

    IEnumerator TimeTaken()
    {
    takingAway= true;
    yield return new WaitForSeconds(1);
    currentScore -= 1;
    timer.text =  ""+ currentScore;
    takingAway= false;
    if(currentScore==3){
        camera_anim.enabled = true;
        Slender.SetActive(true);
        camera_anim.Play("camera_anim2",0,0.0f);
        yield return new WaitForSeconds(3.1f);
        camera_anim.enabled = false;
        Slender.SetActive(false);
    }
   
    if(currentScore==0){
        timer.gameObject.SetActive(false);
        ticking.Stop(); 
        player.transform.position = new Vector3(410, 9, 277);
        yield return new WaitForSeconds(2);
        ticking.Play(); 
        currentScore=30;
        timer.gameObject.SetActive(true);
    }
}



    IEnumerator PauseEvent(){
    yield return new WaitForSeconds(10); 
    timer.gameObject.SetActive(true);
    ticking.Play();       
    pauseEve = false;
    }

    IEnumerator waitSec(){
    yield return new WaitForSeconds(1);  
    Destroy(gameObject);
    Destroy(eventTrigger);
    timer.gameObject.SetActive(false);
    camera_anim.enabled = false;
    Slender.SetActive(false);
    notes_obj.evidenceScore ++;
    notes_obj.evidenceCount.text = "" + notes_obj.evidenceScore;


    }
}

