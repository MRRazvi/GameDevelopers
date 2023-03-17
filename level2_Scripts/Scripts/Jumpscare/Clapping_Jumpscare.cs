using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using EZCameraShake;

public class  Clapping_Jumpscare : MonoBehaviour
{
    public GameObject mom;
    public AudioSource clapping_Audio;
    public AudioSource laugh_audio;
    public AudioSource jumpscare_audio;
    public GameObject G0;
    public Animator camera_anim;
   

void OnTriggerEnter(Collider collision)
{            
 var relativePosition = transform.InverseTransformPoint(collision.transform.position);
   if(relativePosition.x < 0)
    {
        print("yes");
        mom.SetActive(true);
        camera_anim.enabled = true;
        camera_anim.Play("camera_anim", 0,0.0f);
        jumpscare_audio.Play();
        StartCoroutine(waitForSec());
        
        

        
       
    }
}



IEnumerator waitForSec(){
        yield return new WaitForSeconds(1.2f);
        clapping_Audio.Play();
        laugh_audio.Play();
        yield return new WaitForSeconds(2.4f);
        clapping_Audio.Stop();
        laugh_audio.Stop();
        jumpscare_audio.Stop();
        mom.SetActive(false);
        camera_anim.enabled = false;
        yield return new WaitForSeconds(0.04f);
        Destroy(G0);
        
    }
}

// camera_anim
