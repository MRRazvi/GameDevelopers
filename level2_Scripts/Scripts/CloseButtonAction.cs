using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloseButtonAction : MonoBehaviour
{
    [SerializeField] private Image noteImage;
[SerializeField] private Button CloseButton;
 public void CloseBtnAction(){
            noteImage.enabled = false;
            CloseButton.gameObject.SetActive(false);
}
}
