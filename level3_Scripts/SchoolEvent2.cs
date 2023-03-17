using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SchoolEvent2 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource breakTime;
    public bool Trigger= true;
    public AudioSource lunchTime;
    public TMP_Text objText;
    public TMP_Text hints;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  private void OnTriggerEnter(Collider other) {
    if(Trigger){    
        breakTime.Play();
        Trigger = false;
        StartCoroutine(WaitForSeconds());
    }        
}


    IEnumerator WaitForSeconds(){
         yield return new WaitForSeconds(1);
         lunchTime.Play();
        yield return new WaitForSeconds(1.3f);
        objUpdated.SetText("Objective Updated");
        anim.Play("IntroText", 0,0.0f);
        updatedSound.Play();
        objText.SetText("Go to the Canteen area!!!");
        hints.SetText("Stay Focused");

    }
}
