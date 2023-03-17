using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Event : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource killerNeclace;
    public Animator mom_anim;
    public GameObject mom;
    public GameObject Go;
    public GameObject Go1;
    public AudioSource jumpScare_Sound;
    public AudioSource wth;
    public AudioSource updatedSound;
    public GameObject eve3;



    public void Necklace()
    {    
        Go.SetActive(true);
        killerNeclace.Play();  
    }

    public void jumpScare_bedroom()
    {
        mom.SetActive(true);
        Go1.SetActive(true);
        mom_anim.Play("Looking", 0,0.0f);
        jumpScare_Sound.Play();

    }

        public void jumpScare_Exit()
    {
        mom.SetActive(false);
        eve3.SetActive(true);
        updatedSound.Play();
        StartCoroutine(WaitForSeconds());
     
    }

    IEnumerator WaitForSeconds(){
        yield return new WaitForSeconds(1.2f);
        wth.Play();
    }



}
