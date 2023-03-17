using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioScript : MonoBehaviour
{
public AudioSource radio_On;
// public GameObject radioturnOn;

void Start(){
StartCoroutine(AudioPlay());
}


IEnumerator AudioPlay()
{
   yield return new WaitForSeconds(5);
   radio_On.Play();
   yield return new WaitForSeconds(120);
    radio_On.Play();
    yield return new WaitForSeconds(180);
    radio_On.Play();
    yield return new WaitForSeconds(220);
    radio_On.Play();
    yield return new WaitForSeconds(250);
    radio_On.Play();
}






}
