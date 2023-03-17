using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SchoolEvent3 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ComputerClass;
    public bool trigger= true;
    public TMP_Text objText;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public Animator anim;
    public GameObject Go;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


        
        private void OnTriggerEnter(Collider other)
    {
            if(trigger){
                ComputerClass.Play();
                objUpdated.SetText("Objective Updated");
                anim.Play("IntroText", 0,0.0f);
                updatedSound.Play();
                objText.SetText("Go To the Computer Class !!!");
                Destroy(Go);
                trigger= false;
            }



    }
}
