using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomEventHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BedRoom_Event BDEvents = null;
    public bool Triger = true;
    public bool Triger1 = true;
    public bool Triger2 = true;
    // public bool Triger2 = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.name =="bed_necklace" && Triger){
           BDEvents.Necklace();
           Triger=  false;
        }

        if(other.gameObject.name =="bed_jumpScare" && Triger1){
            
           BDEvents.jumpScare_bedroom();
           Triger1=  false;
        }

        if(other.gameObject.name =="bed_jumpScareExit" && Triger2){    
           BDEvents.jumpScare_Exit();
           Triger2= false;
           
        }
    }
}
