using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotsBrokenTrigger : MonoBehaviour {
  
//   public GameObject pots;
    void OnTriggerEnter(Collider collision) {
 
   if(collision.gameObject.name == "Pots") 
			//Object name is the name of the GameObject you want to check for collisions with.
        {
		print("hello");
        }
    }

}