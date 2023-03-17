using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDoorController : MonoBehaviour
{
private Animator doorAnim;
private bool doorOpen = false;

[SerializeField] private string openAnimationName = "DoorOpen";
[SerializeField] private string closeAnimationName = "DoorClose";

// [SerializeField] private TMP_Text showDoorLockedUI;
public AudioSource Open;
public AudioSource Close;

[SerializeField] private float timeToShowUI = 1;
[SerializeField] private GameObject showDoorLockedUI = null;
[SerializeField] private KeyInventory _KeyInventory = null;
[SerializeField] private int waitTimer= 1;
[SerializeField] private bool pauseInteraction = false;

private void Awake(){
    doorAnim = gameObject.GetComponent<Animator>();
}

private IEnumerator pauseDoorInteraction(){
pauseInteraction = true;
yield return new WaitForSeconds(waitTimer);
pauseInteraction= false;

}

public void PlayAnimation(){
    if(_KeyInventory.hasRedKey){

        if(!doorOpen && !pauseInteraction){
            doorAnim.Play("DoorOpen",0,0.0f);
            Open.Play();
            doorOpen=true;
            StartCoroutine(pauseDoorInteraction());
        }
        else if(doorOpen && !pauseInteraction){
            doorAnim.Play("DoorClose",0,0.0f);
            Close.Play();
            doorOpen=false;
            StartCoroutine(pauseDoorInteraction());

        }
    }
        else{
            StartCoroutine(showDoorLocked());
    
        }

 IEnumerator showDoorLocked(){
    showDoorLockedUI.SetActive(true);
    // showDoorLockedUI.gameObject.SetActive(true);
    yield return new WaitForSeconds(timeToShowUI);
    showDoorLockedUI.SetActive(false);
    // showDoorLockedUI.gameObject.SetActive(false);
 }

}


}




