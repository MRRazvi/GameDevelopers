using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotsDownTrigger : MonoBehaviour {
    public Animator Pot_anim;
    public GameObject Pots;
    public GameObject BrokenPots;

     public AudioSource jump_scare_audio;
     public AudioSource pots_broken_audio;
     public GameObject PotsDownGO;
 

    void OnTriggerEnter(Collider collision) {
        //  var relativePosition = transform.InverseTransformPoint(collision.transform.position);
        // if(relativePosition.x < 0)
        // {
      

        // }

        Pot_anim.Play("Down", 0, 0.0f);
        
        StartCoroutine("playAudioAfterSec");
        StartCoroutine("waitForSec");
        pots_broken_audio.Play();

    }

    IEnumerator waitForSec(){
        yield return new WaitForSeconds(1.7F);
        Pots.SetActive(false);
        BrokenPots.SetActive(true);
         yield return new WaitForSeconds(0.7F);
        PotsDownGO.SetActive(false);
        
    }
       IEnumerator playAudioAfterSec(){
        yield return new WaitForSeconds(0.2F);
        jump_scare_audio.Play();
    }
}