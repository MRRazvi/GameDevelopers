using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SchoolEvent6 : MonoBehaviour
{

    public TMP_Text objText;
    public TMP_Text hints;
    public TMP_Text objUpdated;
    public Animator anim;
    public AudioSource updatedSound;
    public GameObject footPrints;
    public bool Trigger= true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other){
        if(Trigger){
            footPrints.SetActive(true);
        objText.SetText("Follow the Foot Prints....!!!");
        hints.SetText("Be Careful");
        objUpdated.SetText("Objective Updated");
        anim.Play("IntroText", 0,0.0f);
        updatedSound.Play();
        Trigger=false;
        }


    }
}
