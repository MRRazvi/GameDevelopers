using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Symptom_Shaking : MonoBehaviour
{
    public bool Trigger = true;
    public TMP_Text objUpdated;
    public AudioSource updatedSound;
    public GameObject eve2;
    public AudioSource Sypmtom_Shaking;

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
                eve2.SetActive(true);
                updatedSound.Play();
                Sypmtom_Shaking.Play();
                Trigger= false;
        }}
}
