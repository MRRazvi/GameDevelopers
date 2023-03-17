using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotsUp_Trigger : MonoBehaviour
{
 public Animator Pot_anim;
//  public Animator camera_anim;
public AudioSource dialogue_1;
public TMP_Text dialogue_txt;
public GameObject PotsUpGO;
public GameObject PotsDownGO;
public TMP_Text hint;

void OnTriggerEnter(Collider collision)
{            
 var relativePosition = transform.InverseTransformPoint(collision.transform.position);

        if(relativePosition.x > 0)
    {
    
    Pot_anim.Play("Up",0,0.0f);
    PotsDownGO.SetActive(true);
    StartCoroutine(waitForSec());
    }
}

    IEnumerator waitForSec(){
        dialogue_1.Play();
        dialogue_txt.gameObject.SetActive(true);

        hint.SetText("Someone is calling from kitchen");
        yield return new WaitForSeconds(3f);  
        PotsUpGO.SetActive(false);
        dialogue_txt.gameObject.SetActive(false);

    }


}
