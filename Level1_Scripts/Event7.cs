using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event7 : MonoBehaviour
{

    public bool trigger= true;
    public GameObject Shadow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
     var relativePosition = transform.InverseTransformPoint(other.transform.position);
   if(relativePosition.z > 0 && trigger)
    {
     Shadow.SetActive(true);
     trigger= false;
    }

    }
}
