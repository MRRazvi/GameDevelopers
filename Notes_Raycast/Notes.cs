using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Notes : MonoBehaviour
{
[SerializeField] private int rayLength = 7;
[SerializeField] private LayerMask layerMaskInteract;
[SerializeField] private string exludeLayerName = null;

[SerializeField] private Image note1_img;
[SerializeField] private Image note2_img;
// [SerializeField] private Image note3_img;
[SerializeField] private Image note4_img;
[SerializeField] private Image note5_img;
[SerializeField] private Image note6_img;
// [SerializeField] private Image note7_img;
[SerializeField] private Image note8_img;
[SerializeField] private Image note9_img;
// [SerializeField] private Image note7_img;
[SerializeField] private Image crosshair = null;

public TMP_Text noteClose_Text;
public TMP_Text obj;
public TMP_Text objUpdated;
public Animator anim;
public TMP_Text dialogue_txt;
public TMP_Text eve_txt;
public TMP_Text eve_txt2;
public TMP_Text eve_txt3;
public AudioSource checkSound;
public AudioSource dialogue_hallucinaton;
public AudioSource dialogue_Confirmed;

public GameObject Rocks;
public AudioSource paper_audio;


public int evidenceScore;
public TMP_Text evidenceCount;

[SerializeField] private KeyCode openNoteKey = KeyCode.Mouse0; 
[SerializeField] private KeyCode closeNoteKey = KeyCode.Escape; 


private bool isCrosshairActive;
private bool doOnce;
private bool isOpen= true;
private bool isRead = true;
private bool isRead2 = true;
private bool Trigger=true;


// For note 1
private const string interactableTag1 = "notes";
// // For note 2
private const string interactableTag2 = "note_1";
// // For note 3
// private const string interactableTag3 = "note_2";
// // For note 4
private const string interactableTag4 = "note_3";

private const string interactableTag5 = "note_4";

private const string interactableTag6 = "note_5";

// private const string interactableTag7 = "note_6";

private const string interactableTag8 = "note_7";

private const string interactableTag9 = "note_8";



private void Update(){
RaycastHit hit;
Vector3 fwd = transform.TransformDirection(Vector3.forward);
int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

if(Physics.Raycast(transform.position, fwd , out hit, rayLength, mask))
{
    // For note 1
   if(hit.collider.CompareTag(interactableTag1)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note1_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

      

    // // For note 2
      if(hit.collider.CompareTag(interactableTag2)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(Trigger){
                obj.SetText("Follow the Path!");
                objUpdated.SetText("Objective Updated");
                anim.Play("IntroText", 0,0.0f);
                checkSound.Play();
                Trigger=false;
                
            }
            note2_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    

    // // // For note 3
    // if(hit.collider.CompareTag(interactableTag3)){
    //         if(!doOnce){
    //         CrosshairChange(true); 
    //     }
    //     if(Input.GetKeyDown(openNoteKey)){
    
    //         note3_img.enabled = true;
    //         noteClose_Text.gameObject.SetActive(true);
    //         // paper3_audio.Play();
    //         // isOpen=false;
          
    //     }
    //      isCrosshairActive=true;
    //       doOnce=true;
    // }

     

    //   // For note 4
    if(hit.collider.CompareTag(interactableTag4)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
                if(isRead){
                StartCoroutine(waitForSec());
                evidenceScore ++;
                evidenceCount.text = "" + evidenceScore;
            }
            note4_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
            isRead= false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    if(hit.collider.CompareTag(interactableTag5)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isRead){
            eve_txt2.gameObject.SetActive(true);
            checkSound.Play();
                // StartCoroutine(waitForSec());
            }
            note5_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    if(hit.collider.CompareTag(interactableTag6)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isRead2){
                StartCoroutine(waitForSec2());
                evidenceScore ++;
                evidenceCount.text = "" + evidenceScore;
                isRead2=false;
            }
            note6_img.enabled = true;
            Rocks.SetActive(false);
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    // if(hit.collider.CompareTag(interactableTag7)){
    //         if(!doOnce){
    //         CrosshairChange(true); 
    //     }
    //     if(Input.GetKeyDown(openNoteKey) && isOpen){
    //         note7_img.enabled = true;
    //         noteClose_Text.gameObject.SetActive(true);
    //         // paper2_audio.Play();
    //         isOpen=false;
    //     }
    //      isCrosshairActive=true;
    //       doOnce=true;
    // }

    if(hit.collider.CompareTag(interactableTag8)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note8_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    if(hit.collider.CompareTag(interactableTag9)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note9_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }




}
if(!(Physics.Raycast(transform.position, fwd , out hit, rayLength, mask) )|| (Physics.Raycast(transform.position, fwd , out hit, rayLength, mask) ))
{
         if(Input.GetKeyDown(closeNoteKey)){
            note1_img.enabled = false;
            note2_img.enabled = false;
            // note3_img.enabled = false;
            note4_img.enabled = false;
            note5_img.enabled = false;
            note6_img.enabled = false;
            // note7_img.enabled = false;
            note8_img.enabled = false;
            note9_img.enabled = false;

            noteClose_Text.gameObject.SetActive(false);
            isOpen=true;
        
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
    if(!doOnce){
        crosshair.color = Color.red;
    }
    else{
        crosshair.color = Color.white;
        isCrosshairActive = false;
    }

}


    IEnumerator waitForSec(){
        yield return new WaitForSeconds(2f); 
        dialogue_txt.gameObject.SetActive(true); 
        dialogue_hallucinaton.Play();
        yield return new WaitForSeconds(1f); 
        dialogue_txt.gameObject.SetActive(false);
        eve_txt.gameObject.SetActive(true);
        checkSound.Play();

    }

    IEnumerator waitForSec2(){
        yield return new WaitForSeconds(2f); 
        dialogue_txt.SetText("Schizophrenia Confirmed");
        dialogue_txt.gameObject.SetActive(true); 
        dialogue_Confirmed.Play();
        yield return new WaitForSeconds(1f); 
        dialogue_txt.gameObject.SetActive(false);
        eve_txt3.gameObject.SetActive(true);
        checkSound.Play();

    }


}

