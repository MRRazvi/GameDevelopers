using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorRayCast : MonoBehaviour
{
[SerializeField] private int rayLength = 5;
[SerializeField] private LayerMask layerMaskInteract;
[SerializeField] private string exludeLayerName = null;

private MyDoorController raycastedObj;
private KeyItemController lookedDoorRaycastedObj;

[SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0; 
[SerializeField] private KeyCode keyPickup = KeyCode.Space; 
[SerializeField] private Image crosshair = null;

private bool isCrosshairActive;
private bool doOnce;

private const string interactableTag = "InteractiveObject";
private const string interactableTag2 = "almirah1";
private const string interactableTag3 = "locked";
private const string interactableTag4 = "radio";

private void Update(){
RaycastHit hit;
Vector3 fwd = transform.TransformDirection(Vector3.forward);
int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

if(Physics.Raycast(transform.position, fwd , out hit, rayLength, mask))
{
    if(hit.collider.CompareTag(interactableTag)){
        if(!doOnce){
            raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
           CrosshairChange(true); 
        }
        isCrosshairActive=true;
        doOnce=true;

        if(Input.GetKeyDown(openDoorKey)){
            raycastedObj.PlayAnimation();
        }

    }
    else if(hit.collider.CompareTag(interactableTag2)){
        if(!doOnce){
            raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
           CrosshairChange(true); 
        }
        isCrosshairActive=true;
        doOnce=true;

        if(Input.GetKeyDown(openDoorKey)){
            raycastedObj.PlayAlmirahAnimation();
        }}

    else if(hit.collider.CompareTag(interactableTag3)){
        if(!doOnce){
            lookedDoorRaycastedObj = hit.collider.gameObject.GetComponent<KeyItemController>();
           CrosshairChange(true); 
        }
        isCrosshairActive=true;
        doOnce=true;

        if(Input.GetKeyDown(keyPickup)){
            lookedDoorRaycastedObj.ObjectInteraction();
        }}

   else if(hit.collider.CompareTag(interactableTag4)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            AudioSource source1 = GameObject.Find("TV_Retro").GetComponent<AudioSource>();
            source1.Stop();
        }
         isCrosshairActive=true;
          doOnce=true;
    }


}
else{
    if(isCrosshairActive){
        CrosshairChange(false);
        doOnce=false;
    }

}

}

void CrosshairChange(bool on)
{
    if(on && !doOnce){
        crosshair.color = Color.red;
    }
    else{
        crosshair.color = Color.white;
        isCrosshairActive = false;
    }

}




}
