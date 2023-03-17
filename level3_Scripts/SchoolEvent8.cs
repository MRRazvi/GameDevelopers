using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolEvent8 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Blame_Note;
    public bool trigger= true;
    public bool trigger1= true;
    public GameObject BloodPrints;
    public GameObject BloodPrints2;
    public GameObject Go_event10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(trigger){
        Blame_Note.SetActive(true);
        BloodPrints.SetActive(false);
        BloodPrints2.SetActive(true);
        Go_event10.SetActive(true);
        trigger=false;
        }


    }
}
