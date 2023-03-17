using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlAttack : MonoBehaviour
{

public GameObject MonsterUpFront;
public GameObject AIMonster;
public GameObject Rocks;
public AudioSource AttackSound;
public Animator camera_anim;
public Event8 obj;


void OnTriggerEnter (Collider triggerInfo) 
    {

           
        if (triggerInfo.gameObject.name=="EnemyAI")
            {
                print("yes");
                AIMonster.SetActive(false);
                MonsterUpFront.SetActive(true);
                AttackSound.Play();
                camera_anim.enabled = true;
                camera_anim.Play("camera_anim2",0,0.0f);
                StartCoroutine(TimeTaken());
            }
        
                if (triggerInfo.gameObject.name=="Event8.1")
            {
                  AIMonster.SetActive(false);
                  Rocks.SetActive(true);

            }

    }  



  IEnumerator TimeTaken()
    {
    yield return new WaitForSeconds(1);
    MonsterUpFront.SetActive(false);
    camera_anim.enabled = false;
    gameObject.transform.position = new Vector3(501, 7, 484);
    obj.obj.SetText("Escape Doctor");
    obj.hint.SetText("Don't Get Caught");
    obj.trigger=true;
    obj.AIMonster.transform.position= new Vector3(509,8,503);
    
    }

}








