using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
