using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private Animator drawerAnim;
    //  public AudioSource Open;
    // public AudioSource Close;

    private bool drawerOpen = false;

    private void Awake() {
        drawerAnim = gameObject.GetComponent<Animator>();
    }


    public void PlayDrawAnimation()
    {
        if(!drawerOpen){
            drawerAnim.Play("OpenDraw", 0,0.0f);
            // Open.Play();
            drawerOpen = true;
        }
        else{
            drawerAnim.Play("CloseDraw", 0,0.0f);
            drawerOpen = false;
            // Close.Play();
        }




    }

        public void PlayAnimation()
    {
        if(!drawerOpen){
            drawerAnim.Play("drawerOpen", 0,0.0f);
            // Open.Play();
            drawerOpen = true;
        }
        else{
            drawerAnim.Play("drawerClose", 0,0.0f);
            drawerOpen = false;
            // Close.Play();
        }




    }



}


// drawerOpen