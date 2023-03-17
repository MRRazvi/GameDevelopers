using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler_MasterRoom : MonoBehaviour
{
 
    [SerializeField] private masterRoomEvents MasterRoomEvents = null;
    public bool Triger = true;

     private void OnTriggerEnter(Collider other)
    {        
        
        if(other.gameObject.name =="MasterRoomEnter" && Triger){
             MasterRoomEvents.EnterMasterRoom();
             Triger = false;
            //  backgroundAudio.Play();
        }

    }



 
}

