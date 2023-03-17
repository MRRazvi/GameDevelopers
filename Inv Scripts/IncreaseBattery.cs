using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBattery : MonoBehaviour
{

    public int _addBatteryBoostToInventory = 1;
    public bool _batteryBoostPickUpActivated;
    // Start is called before the first frame update
    void Start()
    {
        _batteryBoostPickUpActivated = false;
    }

   public void PickUpBatteryBoost() {
    if(_batteryBoostPickUpActivated == true) 
    return;

    Inventory temp = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    temp.BatteryBoostToInventory(_addBatteryBoostToInventory);

    Destroy(gameObject);
    _batteryBoostPickUpActivated = true;
   }
}
