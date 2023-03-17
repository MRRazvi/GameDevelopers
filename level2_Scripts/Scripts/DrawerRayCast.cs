using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawerRayCast : MonoBehaviour
{
[SerializeField] private int rayLength = 3;
[SerializeField] private LayerMask layerMaskInteract;
[SerializeField] private string exludeLayerName = null;

private DrawerController raycastedObj;

[SerializeField] private KeyCode openDrawerKey = KeyCode.Space; 

[SerializeField] private Image crosshair = null;

private bool isCrosshairActive;
private bool doOnce;

private const string interactableTag = "DrawerLayer";
private const string interactableTag1 = "DrawerLayer2";

private void Update(){
raycastGenerator();
}

  void raycastGenerator(){
  RaycastHit hit;
  Vector3 fwd = transform.TransformDirection(Vector3.forward);
  int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

if(Physics.Raycast(transform.position, fwd , out hit, rayLength, mask))
{
    if(hit.collider.CompareTag(interactableTag)){
        if(!doOnce){
            raycastedObj = hit.collider.gameObject.GetComponent<DrawerController>();
           CrosshairChange(true); 
        }
        isCrosshairActive=true;
        doOnce=true;

        if(Input.GetKeyDown(openDrawerKey)){
            raycastedObj.PlayAnimation();
        }

    }
    else if(hit.collider.CompareTag(interactableTag1)){
        if(!doOnce){
            raycastedObj = hit.collider.gameObject.GetComponent<DrawerController>();
           CrosshairChange(true); 
        }
        isCrosshairActive=true;
        doOnce=true;

        if(Input.GetKeyDown(openDrawerKey)){
            raycastedObj.PlayDrawAnimation();
        }

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
        crosshair.color = Color.blue;
    }
    else{
        crosshair.color = Color.white;
        isCrosshairActive = false;
    }

}

}
