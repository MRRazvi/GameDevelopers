using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Event_GuestRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulb;
    public AudioSource brokenBulb_audio;
    public AudioSource doorClose_audio;
    public Animator doorAnim;
    public Animator camera_anim;
    public TMP_Text dialogue_txt;
    public TMP_Text dialogue_txt2;
    public TMP_Text dialogue_txt3;
    public AudioSource dialogue_jesus_christ;
    public AudioSource dialogue_doornotOpening;
    public AudioSource dialogue_may_be_the_killer;
    public AudioSource jump_scare_audio;
    public GameObject Brook;
    public GameObject key;
    

    
    public GameObject hangman;
    public GameObject GO1;
    public GameObject GO2;
    [SerializeField] private KeyInventory _KeyInventory = null;


    public void EnterGuestRoom()
    {
     brokenBulb_audio.Play();  
     Destroy(bulb);
     doorClose_audio.Play();  
     doorAnim.Play("DoorClose", 0, 0.0f);   
    _KeyInventory.hasGuestRoomKey=false; 
     GO1.SetActive(true);
     StartCoroutine(waitForSec());
  
    }

    public void ExitDoorTrigger(){
    dialogue_txt2.gameObject.SetActive(true);
    dialogue_doornotOpening.Play();
    StartCoroutine(waitForSec2());
    }


    public void guestRoomStay(){
    hangman.SetActive(true);
    camera_anim.enabled = true;
    camera_anim.Play("camera_anim", 0,0.0f);
    jump_scare_audio.Play();
    StartCoroutine(waitForSec3());
    StartCoroutine(jumpScareActivator());
  
    }

    IEnumerator jumpScareActivator(){
    //lights On/Off
    yield return new WaitForSeconds(25f);
    Brook.SetActive(true);
    GO2.SetActive(true);
    yield return new WaitForSeconds(10f);
    Brook.SetActive(false);
    GO2.SetActive(false);
    key.SetActive(true);
    yield return new WaitForSeconds(5f);  
    doorAnim.Play("DoorOpen", 0, 0.0f); 
    _KeyInventory.hasGuestRoomKey=true; 


    }    


    // IEnumerator keyActivator(){
    //     // key Appear
    // }



    IEnumerator waitForSec(){
    yield return new WaitForSeconds(0.5f);
     dialogue_jesus_christ.Play();
    dialogue_txt.gameObject.SetActive(true);
    yield return new WaitForSeconds(1.5f);
    dialogue_txt.gameObject.SetActive(false);
    // Destroy(gameObject);
    }

    IEnumerator waitForSec2(){
    yield return new WaitForSeconds(0.5f);
    dialogue_txt2.gameObject.SetActive(false);
    Destroy(GameObject.Find("guestRoomDoor"));
    }

    IEnumerator waitForSec3(){
    yield return new WaitForSeconds(0.5f);
    camera_anim.enabled = false;
    yield return new WaitForSeconds(1.4f);
    dialogue_txt3.gameObject.SetActive(true);
    yield return new WaitForSeconds(1.5f);
    dialogue_txt3.gameObject.SetActive(false);
    dialogue_may_be_the_killer.Play();
    }
}
