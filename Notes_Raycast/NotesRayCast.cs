using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NotesRayCast : MonoBehaviour
{
[SerializeField] private int rayLength = 5;
[SerializeField] private LayerMask layerMaskInteract;
[SerializeField] private string exludeLayerName = null;

[SerializeField] private Image newspaper_img;
[SerializeField] private Image Report;
[SerializeField] private Image Symptoms;
[SerializeField] private Image Medication;
[SerializeField] private Image note1_img;
[SerializeField] private Image note2_img;
[SerializeField] private Image note3_img;
[SerializeField] private Image note4_img;
[SerializeField] private Image note5_img;
[SerializeField] private Image note6_img;
[SerializeField] private Image crosshair = null;

public TMP_Text noteClose_Text;
public TMP_Text objText;
public TMP_Text dialogue_txt;
public TMP_Text dialogue_txt1;
public TMP_Text dialogue_txt2;
public TMP_Text dialogue_txt3;

public int evidenceScore;
public TMP_Text evidenceCount;

// private int noteScore;
// public TMP_Text noteCount;


public TMP_Text hints;

// private int evidenceScore;
// public TMP_Text evidenceCount;

public AudioSource dialogue_strange;
public AudioSource dialogue_report;
public AudioSource dialogue_medicines;
public AudioSource dialogue_symptoms;

public TMP_Text objUpdated;
public AudioSource updatedSound;
public Animator anim;


public AudioSource paper_audio;

[SerializeField] private KeyCode openNoteKey = KeyCode.Mouse0; 
[SerializeField] private KeyCode closeNoteKey = KeyCode.Escape; 


private bool isCrosshairActive;
private bool doOnce;
private bool isOpen= true;
private bool isRead = true;
private bool isReportRead = true;
private bool isMedRead = true;
private bool isSymptomsRead = true;

public GameObject med;
public GameObject rep;
public GameObject eve1;
public GameObject eve3;
public GameObject eve4;


public GameObject jumpscareGO;

// For note 1
private const string interactableTag1 = "newspaper";
// For note 2
private const string interactableTag2 = "note_1";
// For note 3
private const string interactableTag3 = "note_2";
private const string interactableTag4 = "note_3";
private const string interactableTag5 = "note_4";
private const string interactableTag6 = "note_5";
private const string interactableTag7 = "note_6";
private const string interactableTag8 = "report";
private const string interactableTag9 = "Symptoms";
private const string interactableTag10 = "Medication";


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
            newspaper_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    // For note 2
      if(hit.collider.CompareTag(interactableTag2)){
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

    // For note 3
    if(hit.collider.CompareTag(interactableTag3) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note2_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();

            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    if(hit.collider.CompareTag(interactableTag4) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note3_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();

            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

        if(hit.collider.CompareTag(interactableTag5) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note4_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

        if(hit.collider.CompareTag(interactableTag6) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
                if(isRead){
                objText.SetText("Find the bedroom key and Look for evidence");
                hints.SetText("Killing of her mother may be related to the illness");
            
                StartCoroutine(waitForSec());
            }

            note5_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isRead=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }
        if(hit.collider.CompareTag(interactableTag7) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note6_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;

        }
         isCrosshairActive=true;
          doOnce=true;
    }
    if(hit.collider.CompareTag(interactableTag8) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
                if(isReportRead){
                isReportRead=false;
                hints.SetText("Seeing Dead Persons is the main symptoms of necrophoboa ");
                StartCoroutine(waitForSec1());
            }
            Report.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }
        if(hit.collider.CompareTag(interactableTag9) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isMedRead){
               rep.SetActive(true);
                isMedRead=false;
                hints.SetText("These Symptoms are commonly related to Mental Phobias");
                jumpscareGO.SetActive(true);
                StartCoroutine(waitForSec3());
            }
            Medication.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

        if(hit.collider.CompareTag(interactableTag10) ){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
                if(isSymptomsRead){

                isSymptomsRead=false;
                med.SetActive(true);
                hints.SetText("Alprazolam are used to treat Depression due to Mental Trauma");
                StartCoroutine(waitForSec2());
            }
            Symptoms.enabled = true;
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
            newspaper_img.enabled = false;
            note1_img.enabled = false;
            note2_img.enabled = false;
            note3_img.enabled = false;
            note4_img.enabled = false;
            note5_img.enabled = false;
            note6_img.enabled = false;
            Report.enabled = false;
            Medication.enabled = false;
            Symptoms.enabled = false;
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
    if(on && !doOnce){
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
        dialogue_strange.Play();
        yield return new WaitForSeconds(2.2f); 
        dialogue_txt.gameObject.SetActive(false);
        updatedSound.Play();
        anim.Play("IntroText", 0,0.0f);

    }

        IEnumerator waitForSec1(){
        yield return new WaitForSeconds(2f); 
        dialogue_txt1.gameObject.SetActive(true); 
        dialogue_report.Play();
        yield return new WaitForSeconds(2.2f); 
        dialogue_txt1.gameObject.SetActive(false);
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;
        // print(evidenceCount.text);
        objText.SetText("Escape!!!");
        hints.SetText("Basement....");
        objUpdated.SetText("Objective Updated");
        anim.Play("IntroText", 0,0.0f);
        eve4.SetActive(true);
        updatedSound.Play();

    }

        IEnumerator waitForSec2(){
        yield return new WaitForSeconds(2f); 
        dialogue_txt2.gameObject.SetActive(true); 
        dialogue_symptoms.Play();
        yield return new WaitForSeconds(2.2f); 
        dialogue_txt2.gameObject.SetActive(false);
        yield return new WaitForSeconds(6f); 
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;
        eve1.SetActive(true);
        updatedSound.Play();
        }


        IEnumerator waitForSec3(){
        yield return new WaitForSeconds(2f); 
        dialogue_txt3.gameObject.SetActive(true); 
        dialogue_medicines.Play();
        yield return new WaitForSeconds(2.2f); 
        dialogue_txt3.gameObject.SetActive(false);
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;
        eve3.SetActive(true);
        updatedSound.Play();

    }




}
