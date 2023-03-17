using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NotesRay : MonoBehaviour
{
[SerializeField] private int rayLength = 10;
[SerializeField] private LayerMask layerMaskInteract;
[SerializeField] private string exludeLayerName = null;

[SerializeField] private Image note1_img;
[SerializeField] private Image note2_img;
[SerializeField] private Image note3_img;
[SerializeField] private Image note4_img;
[SerializeField] private Image note5_img;
[SerializeField] private Image note6_img;
[SerializeField] private Image note7_img;
[SerializeField] private Image note8_img;
[SerializeField] private Image note9_img;
[SerializeField] private Image note10_img;
[SerializeField] private Image note11_img;
[SerializeField] private Image note12_img;
[SerializeField] private Image note13_img;
[SerializeField] private Image note14_img;
[SerializeField] private Image crosshair = null;

public TMP_Text noteClose_Text;

    public TMP_Text objText;
    public TMP_Text hints;
    public TMP_Text objUpdated;
    public Animator anim;

public GameObject stair;
public GameObject eve1;
public GameObject eve2;
public GameObject eve3;
public GameObject eve5;
public GameObject eve6;
public GameObject event2_Go;
public  GameObject event3_Go;
public AudioSource updatedSound;

public AudioSource paper1_audio;
public AudioSource YourIdCard ;
public AudioSource paper2_audio;
public AudioSource paper3_audio;
public AudioSource paper4_audio;
public AudioSource paper5_audio;
public AudioSource paper6_audio;
public AudioSource paper7_audio;
public AudioSource paper8_audio;
public AudioSource paper9_audio;
public GameObject eve4;

[SerializeField] private KeyCode openNoteKey = KeyCode.Mouse0; 
[SerializeField] private KeyCode closeNoteKey = KeyCode.Escape; 


private bool isCrosshairActive;
private bool doOnce;
private bool isOpen= true;
private bool isRead = true;
private bool isnote_4Read = true;
private bool isnote_5Read = true;
private bool isnote_6Read = true;
private bool isnote_8Read = true;
private bool isnote_9Read = true;



private bool isnote_hate = true;
private bool isnote_blame = true;
private bool isnote_super = true;
private bool isnote_manu = true;

public GameObject Go_event2;
public AudioSource BlamingMe;
public AudioSource gift;
public GameObject GO;

// For note 1
private const string interactableTag1 = "notes";
// For note 2
private const string interactableTag2 = "note_1";
// For note 3
private const string interactableTag3 = "note_2";
// For note 4
private const string interactableTag4 = "note_3";
// For ID Card
private const string interactableTag5 = "note_4";
// For Complain App
private const string interactableTag6 = "note_5";
// For NPD-Superiority
private const string interactableTag7 = "note_6";
// For NPD-Angry
private const string interactableTag8 = "note_7";
// For Sketch
private const string interactableTag9 = "note_8";
// For Book
private const string interactableTag10 = "note_9";

private const string interactableTag11 = "HateNote";
private const string interactableTag12 = "ManiplulateNote";
private const string interactableTag13 = "SuperiorityNote";
private const string interactableTag14 = "BlameNote";


public int evidenceScore;
public TMP_Text evidenceCount;


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
           // obj.SetText("Find the notes!");
            note1_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper1_audio.Play();
            Destroy(Go_event2);
            event3_Go.SetActive(true);

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
            note2_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper2_audio.Play();
            event2_Go.SetActive(true);
            Destroy(GO);
            isOpen=false;
            updatedSound.Play();
            eve1.SetActive(true);
            evidenceScore ++;
            evidenceCount.text = "" + evidenceScore;
            
      
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    

    // For note 3
    if(hit.collider.CompareTag(interactableTag3)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note3_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper3_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

     

      // For note 4
    if(hit.collider.CompareTag(interactableTag4)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note4_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper4_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }


      // For ID Card
    if(hit.collider.CompareTag(interactableTag5)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isnote_4Read){
                isnote_4Read=false;
                StartCoroutine(waitForSec1());
                paper5_audio.Play();
            }
            note5_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }
      

         // For Complain App
    if(hit.collider.CompareTag(interactableTag6)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isnote_5Read){
                isnote_5Read=false;
                StartCoroutine(waitForSec2());
            }
            note6_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper7_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }
      

              // For NPD-Superiority
    if(hit.collider.CompareTag(interactableTag7)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isnote_6Read){
                StartCoroutine(waitForSec4());
                eve5.SetActive(true);
                eve6.SetActive(true);
                updatedSound.Play();
                isnote_6Read=false;
            paper9_audio.Play();
            }
            note7_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }


    
              // For NPD-Angry
    if(hit.collider.CompareTag(interactableTag8)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note8_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper6_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }


             // For Sketch
    if(hit.collider.CompareTag(interactableTag9)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isnote_8Read){
                isnote_8Read=false;
                StartCoroutine(waitForSec3());
            }
            note9_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            paper8_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    
             // For Book
    if(hit.collider.CompareTag(interactableTag10)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            if(isnote_9Read){
                YourIdCard.Play();
                isnote_9Read=false;
                StartCoroutine(waitForSec5());
            }
            note10_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            //paper5_audio.Play();
            isOpen=false;
        }
         isCrosshairActive=true;
          doOnce=true;
    }
      

                 // For Book
    if(hit.collider.CompareTag(interactableTag11)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note11_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            isOpen=false;
            if(isnote_hate){
            updatedSound.Play();
            eve2.SetActive(true);
            evidenceScore ++;
            evidenceCount.text = "" + evidenceScore;
            isnote_hate=false;
            }
        }
         isCrosshairActive=true;
          doOnce=true;
    }

    
    if(hit.collider.CompareTag(interactableTag12)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note12_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            isOpen=false;
            if(isnote_manu){
                StartCoroutine(waitForSec6());
            isnote_manu=false;
            }
        }
         isCrosshairActive=true;
          doOnce=true;
    }
       
    if(hit.collider.CompareTag(interactableTag13)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note13_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            isOpen=false;
        if(isnote_super){
            updatedSound.Play();
            // eve2.SetActive(true);
            evidenceScore ++;
            evidenceCount.text = "" + evidenceScore;
            isnote_super=false;
            }
        }
         isCrosshairActive=true;
          doOnce=true;
            
    }

    if(hit.collider.CompareTag(interactableTag14)){
            if(!doOnce){
            CrosshairChange(true); 
        }
        if(Input.GetKeyDown(openNoteKey) && isOpen){
            note14_img.enabled = true;
            noteClose_Text.gameObject.SetActive(true);
            isOpen=false;
                        
        if(isnote_blame){
            updatedSound.Play();
            BlamingMe.Play();
            eve4.SetActive(true);
            evidenceScore ++;
            evidenceCount.text = "" + evidenceScore;
            isnote_blame=false;
            }
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
            note3_img.enabled = false;
            note4_img.enabled = false;
            note5_img.enabled = false;
            note6_img.enabled = false;
            note7_img.enabled = false;
            note8_img.enabled = false;
            note9_img.enabled = false;
            note10_img.enabled = false;
            note11_img.enabled = false;
            note12_img.enabled = false;
            note13_img.enabled = false;
            note14_img.enabled = false;
            paper2_audio.Stop();
            paper1_audio.Stop();
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

 IEnumerator waitForSec1(){
        yield return new WaitForSeconds(2f); 
       // dialogue_txt1.gameObject.SetActive(true); 
        //dialogue_report.Play();
        yield return new WaitForSeconds(2.2f); 
       // dialogue_txt1.gameObject.SetActive(false);
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;
        updatedSound.Play();
        print(evidenceCount.text);

    }

     IEnumerator waitForSec2(){
        yield return new WaitForSeconds(2f); 
       // dialogue_txt2.gameObject.SetActive(true); 
        //dialogue_symptoms.Play();
        yield return new WaitForSeconds(2.2f); 
        //dialogue_txt2.gameObject.SetActive(false);
        updatedSound.Play();
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;
        }

        IEnumerator waitForSec3(){
        yield return new WaitForSeconds(2f); 
       // dialogue_txt3.gameObject.SetActive(true); 
        //dialogue_medicines.Play();
        yield return new WaitForSeconds(2.2f); 
        //dialogue_txt3.gameObject.SetActive(false);
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;

        }

        IEnumerator waitForSec4(){
        yield return new WaitForSeconds(2f); 
        //dialogue_txt3.gameObject.SetActive(true); 
        //dialogue_medicines.Play();
        yield return new WaitForSeconds(2.2f); 
        //dialogue_txt3.gameObject.SetActive(false);
        evidenceScore ++;
        evidenceCount.text = "" + evidenceScore;
        }

        IEnumerator waitForSec5(){
        yield return new WaitForSeconds(2f); 
        //dialogue_txt3.gameObject.SetActive(true); 
        //dialogue_medicines.Play();
        yield return new WaitForSeconds(2.2f); 
        //dialogue_txt3.gameObject.SetActive(false);
        evidenceScore ++;
        updatedSound.Play();
        evidenceCount.text = "" + evidenceScore;
        }


        IEnumerator waitForSec6(){
        yield return new WaitForSeconds(1f); 
            updatedSound.Play();
            evidenceScore ++;
            eve3.SetActive(true);
            gift.Play();
            objText.SetText("Go to the Stairs....!!!");
            hints.SetText("He may decisive you again");
            objUpdated.SetText("Objective Updated");
            anim.Play("IntroText", 0,0.0f);
            Destroy(stair);
            evidenceCount.text = "" + evidenceScore;
        }
}
