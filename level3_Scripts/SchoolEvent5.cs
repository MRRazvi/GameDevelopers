using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolEvent5 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource KilledHim;

    public bool Trigger=true;
    public GameObject Go;
    public GameObject Go_SketchRoom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
     if(Trigger){
        KilledHim.Play();
        Go_SketchRoom.SetActive(true);
        Go.SetActive(true);
        Trigger=false;
     }   

    }



}
