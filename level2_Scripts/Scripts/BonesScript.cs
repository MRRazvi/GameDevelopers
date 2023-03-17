using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bone;

        private void OnTriggerEnter(Collider other)
    {        
        bone.SetActive(true);
        gameObject.SetActive(false);

    }




}
