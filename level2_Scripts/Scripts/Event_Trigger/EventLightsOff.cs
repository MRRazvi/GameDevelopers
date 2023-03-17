using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLightsOff : MonoBehaviour
{
    public Animator LightsOff_anim;
    public AudioSource brokenBulb_audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnTriggerEnter(Collider other){
     var relativePosition = transform.InverseTransformPoint(other.transform.position);
   if(relativePosition.z > 0)
    {

        LightsOff_anim.Play("LightsOff",0, 0.0f);
        StartCoroutine(waitForSec());
    }

}


IEnumerator waitForSec(){
yield return new WaitForSeconds(0.2f);
brokenBulb_audio.Play();
yield return new WaitForSeconds(1.5f);
Destroy(gameObject);

}
}
