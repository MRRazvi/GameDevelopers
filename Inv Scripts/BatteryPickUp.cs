using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BatteryPickUp Class

This class represents a battery pick-up item in a Unity game.
When the player interacts with the battery pick-up, it adds batteries to their inventory.

Public Variables:
    - _addBatteriesToInventory: The number of batteries to add to the inventory.
    - _batteryPickUpActivated: Indicates if the battery pick-up has been activated.

Private Variables:
    None.

Methods:
    - Start(): Initializes the _batteryPickUpActivated variable.
    - PickUpBattery(): Adds batteries to the player's inventory when picked up.

Author: Mubashir Rasool Razvi
Date: May 2023
*/

public class BatteryPickUp : MonoBehaviour
{
    public int _addBatteriesToInventory = 1;
    public bool _batteryPickUpActivated;

    void start() {
      _batteryPickUpActivated = false;
    }

    public void PickUpBattery() {
        if(_batteryPickUpActivated == true)
        return;

        Inventory temp = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        temp.BatteryToInventory(_addBatteriesToInventory);

        Destroy(gameObject);
        _batteryPickUpActivated = true;
    }
}
