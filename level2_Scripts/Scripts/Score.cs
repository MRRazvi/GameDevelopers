using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int currentScore;
    public TMP_Text boneCount;
  
    void Start () {
        currentScore = 1;
   
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "bone")  {
              boneCount.text = "" + currentScore;
              currentScore ++;
        }
    }



}
