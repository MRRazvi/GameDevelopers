using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyRayCast : MonoBehaviour

{
[SerializeField] private int rayLength = 5;
[SerializeField] private LayerMask layerMaskInteract;
[SerializeField] private string exludeLayerName = null;
public GameObject guiText; 


private const string interactableTag = "keyGui";

 private void Start() {
     guiText.SetActive(false);
}

private void Update(){
RaycastHit hit;
Vector3 fwd = transform.TransformDirection(Vector3.forward);
int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

if(Physics.Raycast(transform.position, fwd , out hit, rayLength, mask))
{
    if(hit.collider.CompareTag(interactableTag)){
       StartCoroutine(showkeyGui());
    print("hh");

    }
}

    else{
       StartCoroutine(hidekeyGui());
    }

}

 IEnumerator hidekeyGui(){
  
    yield return new WaitForSeconds(0.5f);
     guiText.SetActive(false);

 }

  IEnumerator showkeyGui(){
  
    yield return new WaitForSeconds(0.5f);
     guiText.SetActive(true);

 }


}
