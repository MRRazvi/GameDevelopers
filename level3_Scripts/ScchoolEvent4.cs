using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScchoolEvent4 : MonoBehaviour
{

    public Animator teacher_Anim;
    public AudioSource FindNoteBook;
    public bool Trigger= true;
    public GameObject Go;
    public TMP_Text objText;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public GameObject Teacher_Go;
    public Animator anim;

    private void OnTriggerEnter(Collider other){
        if(Trigger){
        Teacher_Go.SetActive(true);
        teacher_Anim.Play("Pointing", 0,0.0f);
        FindNoteBook.Play();
        Go.SetActive(true);
        objUpdated.SetText("Objective Updated");
        anim.Play("IntroText", 0,0.0f);
        updatedSound.Play();
        objText.SetText("Find the note Book !!!");
        Trigger= false;
        }


    }
}
