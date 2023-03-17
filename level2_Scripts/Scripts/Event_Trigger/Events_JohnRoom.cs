using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_JohnRoom : MonoBehaviour
{

    public Animator doorAnim;
    public GameObject Brook;
    public Animator brook_laying;
    public AudioSource doorClose_audio;
    public AudioSource whisper_audio;
    public GameObject Blood;
    public GameObject key;
    public GameObject Exit_Go;

    public GameObject redLights;
    [SerializeField] private KeyInventory _KeyInventory = null;


    public void EnterJohnRoom()
    {
     doorClose_audio.Play();  
     doorAnim.Play("DoorClose", 0, 0.0f);   
     _KeyInventory.hasJohnRoomKey = false;
    }

    public void johnRoomStay(){
    StartCoroutine(jumpScareActivator());
    }

    public void johnRoomExit(){
     doorAnim.Play("DoorOpen", 0, 0.0f);   
     _KeyInventory.hasJohnRoomKey = true;
    }

    IEnumerator jumpScareActivator(){
    yield return new WaitForSeconds(25f);
    redLights.SetActive(true);
    whisper_audio.Play();
    yield return new WaitForSeconds(10f);
    Brook.SetActive(true);
    brook_laying.Play("laying" , 0 ,0.0f);
    Blood.SetActive(true);
    yield return new WaitForSeconds(5f);
    brook_laying.GetComponent<Animator>().enabled = false;
    yield return new WaitForSeconds(3f);
    key.SetActive(true);
    Exit_Go.SetActive(true);
}    






}
