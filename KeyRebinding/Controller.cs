using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

   

	void Start ()
	{
	 Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () 
	{

		if(Input.GetKey(GameManager.GM.forward))
			transform.position += transform.forward / 18;
	
		if( Input.GetKey(GameManager.GM.backward))
			transform.position += -transform.forward / 18;
		
		if( Input.GetKey(GameManager.GM.left))
			transform.position += -transform.right / 18;
		
		if( Input.GetKey(GameManager.GM.right))
			transform.position += transform.right / 18;

		if( Input.GetKey(GameManager.GM.jump))
			transform.position += transform.up / 2;
                  
                  Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
	}
}