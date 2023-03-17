using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolEvent10 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Superiority_Note;
    public bool trigger= true;
    public AudioSource PlayWithme;
    public GameObject lastEvent;
    // public bool trigger1= true;
    // public GameObject BloodPrints;
    // public GameObject BloodPrints2;
    // public GameObject Go_event10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(trigger){
        Superiority_Note.SetActive(true);
        lastEvent.SetActive(true);
        PlayWithme.Play();
        trigger=false;
        }


    }
}
