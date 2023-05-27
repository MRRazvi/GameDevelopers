using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
IncreaseBattery Class

This class represents a battery boost pick-up item in a Unity game.
When the player interacts with the battery boost pick-up, it adds battery boosts to their inventory.

Public Variables:
    - _addBatteryBoostToInventory: The number of battery boosts to add to the inventory.
    - _batteryBoostPickUpActivated: Indicates if the battery boost pick-up has been activated.

Private Variables:
    None.

Methods:
    - Start(): Initializes the _batteryBoostPickUpActivated variable.
    - PickUpBatteryBoost(): Adds battery boosts to the player's inventory when picked up.

Author: Mubashir Rasool Razvi
Date: May 2023
*/


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
