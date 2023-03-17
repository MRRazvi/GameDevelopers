using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolEvent7 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Go;
    public GameObject Des_FootPrint;
    public GameObject Event9_Go;
    public bool Trigger= true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(Trigger){
        Go.SetActive(true);
        Event9_Go.SetActive(true);
        Destroy(Des_FootPrint);
            Trigger = false;
        }
      
    }
}
