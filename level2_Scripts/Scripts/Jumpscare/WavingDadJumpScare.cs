using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavingDadJumpScare : MonoBehaviour
{
    public GameObject PlayerCamera;
    public GameObject Camera;
    public GameObject dad;
    public AudioSource dadAudio;
    public AudioSource jumpscare_Audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

     void OnTriggerEnter(Collider other) {
         var relativePosition = transform.InverseTransformPoint(other.transform.position);

    if (relativePosition.x > 0) 
    {
        
        dad.SetActive(true);
        jumpscare_Audio.Play();
        dadAudio.Play();
        PlayerCamera.SetActive(false);
        Camera.SetActive(true);
        StartCoroutine(ExampleCoroutine());
        
    }
   
    }

    
      IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1.3f);
        Camera.SetActive(false);
        PlayerCamera.SetActive(true);
        Destroy(gameObject);
        Destroy(dad);
        // yield return new WaitForSeconds(0.5f);

       
    }
    
}
