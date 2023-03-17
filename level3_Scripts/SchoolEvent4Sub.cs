using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SchoolEvent4Sub : MonoBehaviour
{
    public Animator teacher_Anim;
    public AudioSource FindNoteBook;
    public bool Trigger= true;
    public GameObject Teacher_Go;
    public GameObject Teacher_Go2;
    public TMP_Text objText;
    public TMP_Text hintText;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;
    public GameObject eve3_Note;

    private void OnTriggerEnter(Collider other){
        if(Trigger){
        Teacher_Go.SetActive(true);
        eve3_Note.SetActive(true);
        teacher_Anim.Play("Pointing", 0,0.0f);
        FindNoteBook.Play();
        Destroy(Teacher_Go2);
        objUpdated.SetText("Objective Updated");
        anim.Play("IntroText", 0,0.0f);
        updatedSound.Play();
        objText.SetText("Don't leave Find here !!!");
        hintText.SetText("Something is Fishy");
        Trigger= false;
        }


    }
}
