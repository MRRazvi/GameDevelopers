using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SchoolEvent1 : MonoBehaviour
{
    public GameObject go;
    public AudioSource angerSound;
    public AudioSource whyareyouhere;

    public TMP_Text objText;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        StartCoroutine(WaitForSeconds());

    }

    IEnumerator WaitForSeconds(){
        yield return new WaitForSeconds(2);
        go.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        angerSound.Play();
        yield return new WaitForSeconds(2.5f);
        whyareyouhere.Play();
        yield return new WaitForSeconds(2.7f);
        updatedSound.Play();
        objUpdated.SetText("Objective Updated");
        anim.Play("IntroText", 0,0.0f);
        objText.SetText("Pick Up the note");



    }
}
