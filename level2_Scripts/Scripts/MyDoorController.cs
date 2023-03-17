using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;
     public AudioSource Open;
    public AudioSource Close;

    private bool doorOpen = false;

    private void Awake() {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if(!doorOpen){
            doorAnim.Play("DoorOpen", 0,0.0f);
            Open.Play();
            doorOpen = true;
        }
        else{
            doorAnim.Play("DoorClose", 0,0.0f);
            doorOpen = false;
            Close.Play();
        }

    }

       public void PlayAlmirahAnimation()
    {
        if(!doorOpen){
            doorAnim.Play("almirahOpen", 0,0.0f);
            doorOpen = true;
        }
        else{
            doorAnim.Play("almirahClose", 0,0.0f);
            doorOpen = false;
        }

    }


}

// almirahOpen