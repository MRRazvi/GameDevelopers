using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Chair_Trigger : MonoBehaviour
{
 public Animator wheel_Chair;
 public Animator camera_anim;
 public AudioSource wheel_Chair_crash;
 public AudioSource jump_scare;
 public GameObject wheel_Chair_go;

void OnTriggerEnter(Collider collision)
{            
 var relativePosition = transform.InverseTransformPoint(collision.transform.position);
    if(relativePosition.x < 0)
    {
        wheel_Chair.Play("wheel_Chair_JumpScare", 0,0.0f);
        camera_anim.enabled = true;
        camera_anim.Play("camera_anim", 0,0.0f);
        wheel_Chair_crash.Play();
        jump_scare.Play();
        StartCoroutine("waitForSec");
         
    }
}

    IEnumerator waitForSec(){
         yield return new WaitForSeconds(1);
        camera_anim.enabled = false;
        yield return new WaitForSeconds(2);
        wheel_Chair_go.SetActive(false);
    }
}
