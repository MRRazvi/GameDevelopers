using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterRoomEvents : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mom;
    public Animator mom_anim;
    public Animator camera_anim;
    public AudioSource jumpscare_audio;
    
    public void EnterMasterRoom()
    {
    mom.SetActive(true); 
    mom_anim.Play("pointing", 0, 0.0f);   
    camera_anim.enabled = true;
    camera_anim.Play("camera_anim", 0,0.0f);
    StartCoroutine(waitforsec());
    }
 
    IEnumerator waitforsec(){
    yield return new WaitForSeconds(0.5f);
    jumpscare_audio.Play();
     yield return new WaitForSeconds(2f);
    camera_anim.enabled = false;
    mom.SetActive(false); 
    }

}
