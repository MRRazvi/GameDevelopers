using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyItemController : MonoBehaviour
{
[SerializeField] private bool redDoor = false;
[SerializeField] private bool redKey = false;
[SerializeField] private bool LaungeDoor = false;
[SerializeField] private bool LaungeKey = false;
public TMP_Text obj;

[SerializeField] private bool BasementDoor = false;
[SerializeField] private bool BasementKey = false;

[SerializeField] private bool guestRoomDoor = false;
[SerializeField] private bool guestRoomKey = false;
[SerializeField] private bool JohnRoomDoor = false;
[SerializeField] private bool JohnRoomKey = false;


[SerializeField] private KeyInventory _KeyInventory = null;
   private KeyDoorController doorObject;
   private TvLaungeDoorController laungeDoorObject;
   private basementDoorController BasementDoorObject;
   private GuestRoomDoorController GuestRoomDoorObject;
   private johnroomDoorController JohnRoomDoorObject;


   public TMP_Text objUpdated;
   public AudioSource updatedSound;
   public Animator anim;
   
//    public GameObject redkey;

   private void Start()
   {
    if(redDoor){
    doorObject = GetComponent<KeyDoorController>();
    }

    if(LaungeDoor){
    laungeDoorObject = GetComponent<TvLaungeDoorController>();
    }

    if(BasementDoor){
    BasementDoorObject = GetComponent<basementDoorController>();
    }

     if(guestRoomDoor){
    GuestRoomDoorObject = GetComponent<GuestRoomDoorController>();
    }

    if(JohnRoomDoor){
        JohnRoomDoorObject = GetComponent<johnroomDoorController>();
    }
    // StartCoroutine(AppearBedroomKeyOnScene());

   }

    public void ObjectInteraction(){
        if(redDoor){
            doorObject.PlayAnimation();
            
        }
        else if(redKey){
            _KeyInventory.hasRedKey =  true;
            obj.SetText("Explore the Bedroom");
            objUpdated.SetText("Objective Updated");
            anim.Play("IntroText", 0,0.0f);
            updatedSound.Play();
            StartCoroutine(WaitForSeconds());
            

        }

        if(LaungeDoor){
            laungeDoorObject.PlayAnimation();
        }
        else if(LaungeKey){
            _KeyInventory.hasLaungeKey =  true;
            StartCoroutine(WaitForSeconds());
            obj.SetText("Explore the Launge");
            objUpdated.SetText("Objective Updated");
            updatedSound.Play();
            anim.Play("IntroText", 0,0.0f);

        }

        if(BasementDoor){
            BasementDoorObject.PlayAnimation();
        }
        else if(BasementKey){
            _KeyInventory.hasBasementKey =  true;
           StartCoroutine(WaitForSeconds());
            obj.SetText("Explore the Basement");
            objUpdated.SetText("Objective Updated");
            updatedSound.Play();
            anim.Play("IntroText", 0,0.0f);

        }

        if(JohnRoomDoor){
            JohnRoomDoorObject.PlayAnimation();
        }
        else if(JohnRoomKey){
            _KeyInventory.hasJohnRoomKey =  true;
            StartCoroutine(WaitForSeconds());
            obj.SetText("Explore the John's Room");
            objUpdated.SetText("Objective Updated");
            updatedSound.Play();
            anim.Play("IntroText", 0,0.0f);

        }

        if(guestRoomDoor){
            GuestRoomDoorObject.PlayAnimation();
        }
        else if(guestRoomKey){
            _KeyInventory.hasGuestRoomKey =  true;
            StartCoroutine(WaitForSeconds());
            obj.SetText("Explore the Guest Room");
            objUpdated.SetText("Objective Updated");
            updatedSound.Play();
            anim.Play("IntroText", 0,0.0f);


        }



    }


    IEnumerator WaitForSeconds(){
        yield return new WaitForSeconds(0.6f);
        gameObject.SetActive(false);
        
    }
// private IEnumerator AppearBedroomKeyOnScene(){
// // redkey.SetActive(false);

// yield return new WaitForSeconds(10);
// redkey.SetActive(true);
// // GameObject.Find("bedroomkey").SetActive(true);

// }


}
