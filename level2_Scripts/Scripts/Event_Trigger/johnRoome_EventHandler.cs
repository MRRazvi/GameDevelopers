using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class johnRoome_EventHandler : MonoBehaviour
{
    [SerializeField] private Events_JohnRoom JohnRoomEvents = null;
    public bool Triger = true;
    public bool Triger1 = true;
    public bool Triger2 = true;
    
    private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.name =="enterJohnRoom" && Triger){
             JohnRoomEvents.EnterJohnRoom();
             Triger = false;
            //  backgroundAudio.Play();
        }

         if(other.gameObject.name =="JohnRoomStay" && Triger1){
             JohnRoomEvents.johnRoomStay();
             Triger1= false;
        }


        if(other.gameObject.name =="JohnRoomExit" && Triger2){
             JohnRoomEvents.johnRoomExit();
             Triger2= false;
        }
    }




}
