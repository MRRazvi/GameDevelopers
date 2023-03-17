using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launge_Events : MonoBehaviour
{

    public AudioSource Bloody_Weapon;
    public bool trigger = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(trigger){
            Bloody_Weapon.Play();
            trigger= false;
        }

    }



}
