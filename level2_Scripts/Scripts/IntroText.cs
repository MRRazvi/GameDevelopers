using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroText : MonoBehaviour
{
    public GameObject introText;
    // Start is called before the first frame update
    void Start()
    {
        introText.SetActive(false);
        StartCoroutine("waitForSec");
    }

    // Update is called once per frame
    IEnumerator waitForSec(){
        yield return new WaitForSeconds(120);
        introText.SetActive(true);


    }

}
