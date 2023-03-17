using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event2 : MonoBehaviour
{

    public GameObject demon;
    public GameObject Go;
    public GameObject Rocks;
    public GameObject waterBottle_Go;
    // public TMP_Text dialogue_txt;
    // public GameObject G0;
    public TMP_Text obj;
    public AudioSource dialogue_suffocation;
    public AudioSource jumpscare_audio;
    public Animator camera_anim;
    public bool trigger= true;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collision)
{            
 var relativePosition = transform.InverseTransformPoint(collision.transform.position);
   if(relativePosition.z < 0 && trigger)
    {

        Go.SetActive(true);
        waterBottle_Go.SetActive(true);
        demon.SetActive(true);
        camera_anim.enabled = true;
        camera_anim.Play("camera_anim2", 0,0.0f);
        jumpscare_audio.Play();
        StartCoroutine(waitForSec()); 
        trigger= false;   
    }
    
}





IEnumerator waitForSec(){

        yield return new WaitForSeconds(1.2f);
        demon.SetActive(false);
        camera_anim.enabled = false;
        yield return new WaitForSeconds(1.4f);
        dialogue_suffocation.Play();
        // Destroy(gameObject);
         yield return new WaitForSeconds(1.7f);
        obj.SetText("Find Water Bottle Quickly!!!");
        objUpdated.SetText("Objective Updated");
        updatedSound.Play();
        anim.Play("IntroText", 0,0.0f);
        Rocks.SetActive(false);
        
    }
}
