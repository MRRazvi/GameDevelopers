using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestRoomEventHandler : MonoBehaviour
{
    [SerializeField] private Event_GuestRoom EnterGuestRoomEvent = null;
    public AudioSource backgroundAudio;
    public bool Triger = true;
    public bool Triger2 = true;
    private void OnTriggerEnter(Collider other)
    {        
     //     var relativePosition = transform.InverseTransformPoint(other.transform.position);
        if(other.gameObject.name =="enterGuestRoom" && Triger){
             EnterGuestRoomEvent.EnterGuestRoom();
             Triger = false;
             backgroundAudio.Play();

        }
         if(other.gameObject.name =="guestRoomDoor"){
             EnterGuestRoomEvent.ExitDoorTrigger();
        }
        if(other.gameObject.name =="guestRoomStay"&& Triger2){
             EnterGuestRoomEvent.guestRoomStay();
             Triger2= false;
               backgroundAudio.Stop();
        }
    }


}
