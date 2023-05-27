using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Flashlight Class

This class represents a flashlight in a Unity game.
It manages the functionality of the flashlight, including turning it on and off,
adjusting power levels, and handling battery drain and charging.

The flashlight can operate in different states: off, low power, high power, and flashing.
The state transitions are controlled by user input and battery power levels.

Public Variables:
    - _lowPowerIntensity: The intensity of the flashlight in low power mode.
    - _lowPowerSpotAngle: The spot angle of the flashlight in low power mode.
    - _lowPowerRange: The range of the flashlight in low power mode.
    - _highPowerIntensity: The intensity of the flashlight in high power mode.
    - _highPowerSpotAngle: The spot angle of the flashlight in high power mode.
    - _highPowerRange: The range of the flashlight in high power mode.
    - _lowDrainBatterySpeed: The speed at which the battery drains in low power mode.
    - _highDrainBatterySpeed: The speed at which the battery drains in high power mode.
    - _maxFlickerSpeed: The maximum speed of flashlight flickering.
    - _minFlickerSpeed: The minimum speed of flashlight flickering.
    - _maximumBatteryPower: The maximum battery power level.
    - _currentBatteryPower: The current battery power level.
    - _batteryPowerModifier: The amount of battery power added or subtracted.
    - _batteryBarLength: Length of the battery bar.
    - _flashlightState: The current state of the flashlight.

Private Variables:
    - _flashlight: Reference to the Light component attached to the flashlight GameObject.
    - _flashlightAudio: Reference to the AudioSource component attached to the flashlight GameObject.
    - _switch: AudioClip for the flashlight switch sound.

Private Methods:
    - Start(): Initializes the flashlight and starts the FlashlightManager coroutine.
    - Update(): Update loop for the flashlight logic.
    - FlashlightManager(): Coroutine that manages the flashlight state transitions.
    - FlashlightOff(): Logic for when the flashlight is turned off.
    - FlashlightOnLow(): Logic for when the flashlight is on in low power mode.
    - FlashlightOnHigh(): Logic for when the flashlight is on in high power mode.
    - FlashlightFlashing(): Logic for when the flashlight is flashing.
    - FlashlightModifier(): Coroutine for the flashlight flickering effect.

Public Methods:
    - AddBattery(int _batteryPowerAmount): Adds battery power to the flashlight.
    - IncreaseMaxBattery(int _increaseMaxBatteryAmount): Increases the maximum battery power.

Author: Mubashir Rasool Razvi
Date: May 2023
*/

public class Flashlight : MonoBehaviour
{
    private Light _flashlight;
    private AudioSource _flashlightAudio;
    public AudioClip _switch;

    public float _lowPowerIntensity = 3f;
    public float _lowPowerSpotAngle = 40f;
    public float _lowPowerRange = 30f;

    public float _highPowerIntensity = 6f;
    public float _highowerSpotAngle = 20f;
    public float _highPowerRange = 45f;

    public float _lowDrainBatterySpeed = 1f;
    public float _highDrainBatterySpeed = 5.0f;

    public float _maxFlickerSpeed = 1f;
    public float _minFlickerSpeed = 0.1f;

    
    public static float _maximumBatteryPower = 100f;
    public static float _currentBatteryPower = 0f;

    public int _batteryPowerModifier = 10;
    public float _batteryBarLength;
    private FlashlightState _flashlightState;

    private enum FlashlightState {
        FlashlightOff = 0,
        FlashlightOnLow = 1,
        FlashlightOnHigh = 2,
        FlashlightFlashing = 3
    }

    void Start() {
         _flashlightAudio = GetComponent<AudioSource>();
         
        _flashlight = GetComponentInChildren<Light> ();
        _flashlight.enabled = false;

        StartCoroutine("FlashlightManager");
        _flashlightState = Flashlight.FlashlightState.FlashlightOff;
        _currentBatteryPower = _maximumBatteryPower;
    }

    void Update() {

        
        }

        private IEnumerator FlashlightManager() {
            while(true) {
                switch(_flashlightState) {
                   case FlashlightState.FlashlightOff:
                   FlashlightOff();
                   break;
                   case FlashlightState.FlashlightOnLow:
                   FlashlightOnLow();
                   break;
                   case FlashlightState.FlashlightOnHigh:
                   FlashlightOnHigh();
                   break;
                   case FlashlightState.FlashlightFlashing:
                   FlashlightFlashing();
                   break;
                }
                yield return null;
            }
        }

        private void FlashlightOff() {
            Debug.Log("FlashlightOff");
           if(Input.GetKeyDown(KeyCode.F) && _currentBatteryPower > _batteryPowerModifier) {
            _flashlightAudio.PlayOneShot(_switch);
            _flashlight.enabled = true;
            _flashlight.intensity = _lowPowerIntensity;
            _flashlight.spotAngle = _lowPowerSpotAngle;
            _flashlight.range = _lowPowerRange;
            _flashlightState = Flashlight.FlashlightState.FlashlightOnLow;

        }
         if(Input.GetKeyDown(KeyCode.F) && _currentBatteryPower < _batteryPowerModifier) {
            _flashlightAudio.PlayOneShot(_switch);
            _flashlight.enabled = true;
            _flashlight.intensity = _lowPowerIntensity;
            _flashlight.spotAngle = _lowPowerSpotAngle;
            _flashlight.range = _lowPowerRange;
            _flashlightState = Flashlight.FlashlightState.FlashlightFlashing;

        }
        if(Input.GetKeyDown(KeyCode.F) && _currentBatteryPower == 0)
            _flashlightAudio.PlayOneShot(_switch);
        }

        private void FlashlightOnLow() {
              Debug.Log("FlashlightOnLow");
              _currentBatteryPower -= _lowDrainBatterySpeed * Time.deltaTime;
              if(Input.GetMouseButton (1) && _currentBatteryPower > _batteryPowerModifier) {
            _flashlight.intensity = _highPowerIntensity;
            _flashlight.spotAngle = _highowerSpotAngle;
            _flashlight.range = _highPowerRange;
            _flashlightState = Flashlight.FlashlightState.FlashlightOnHigh;
              }

              if(_currentBatteryPower < _batteryPowerModifier)
               _flashlightState = Flashlight.FlashlightState.FlashlightFlashing;

              if(Input.GetKeyDown(KeyCode.F)) {
                 _flashlightAudio.PlayOneShot(_switch);
                 _flashlight.enabled = false;
                 _flashlightState = Flashlight.FlashlightState.FlashlightOff;

              }
        }

        private void FlashlightOnHigh() {
            Debug.Log("FlashlightOnHigh");
            _currentBatteryPower -= _highDrainBatterySpeed * Time.deltaTime;

            if(Input.GetMouseButtonUp (1) && _currentBatteryPower > _batteryPowerModifier) {
            _flashlight.intensity = _lowPowerIntensity;
            _flashlight.spotAngle = _lowPowerSpotAngle;
            _flashlight.range = _lowPowerRange;
            _flashlightState = Flashlight.FlashlightState.FlashlightOnLow;
              }

            if(_currentBatteryPower < _batteryPowerModifier) {
            _flashlight.intensity = _lowPowerIntensity;
            _flashlight.spotAngle = _lowPowerSpotAngle;
            _flashlight.range = _lowPowerRange;
               _flashlightState = Flashlight.FlashlightState.FlashlightFlashing;
            }

             if(Input.GetKeyDown(KeyCode.F)) {
                 _flashlightAudio.PlayOneShot(_switch);
                 _flashlight.enabled = false;
                 _flashlightState = Flashlight.FlashlightState.FlashlightOff;

              }
        }

        private void FlashlightFlashing() {
            Debug.Log("FlashlightFlashing");
            _currentBatteryPower -= _lowDrainBatterySpeed * Time.deltaTime;
            StartCoroutine("FlashlightModifier");

            if(Input.GetKeyDown(KeyCode.F)) {
                 _flashlightAudio.PlayOneShot(_switch);
                 _flashlight.enabled = false;
                 StopCoroutine("FlashlightModifier");
                 _flashlightState = Flashlight.FlashlightState.FlashlightOff;

              }

              if(_currentBatteryPower > _batteryPowerModifier)
              _flashlightState = Flashlight.FlashlightState.FlashlightOnLow;

              if(_currentBatteryPower > 0)
              return; 

              if(_currentBatteryPower < 0)
              _currentBatteryPower = 0;
        
              if(_currentBatteryPower == 0) {
                _flashlight.enabled = false;
                 StopCoroutine("FlashlightModifier");
                 _flashlightState = Flashlight.FlashlightState.FlashlightOff;
              }
        }

    

    private IEnumerator FlashlightModifier() {
         _flashlight.enabled = true;
         yield return new WaitForSeconds (Random.Range (_minFlickerSpeed, _maxFlickerSpeed));

          _flashlight.enabled = false;
         yield return new WaitForSeconds (Random.Range (_minFlickerSpeed, _maxFlickerSpeed));
    }
    public void AddBattery(int _batteryPowerAmount) {
        _currentBatteryPower += _batteryPowerAmount;

       if(_currentBatteryPower > _maximumBatteryPower)
        _currentBatteryPower = _maximumBatteryPower;
    }

    public void IncreaseMaxBattery(int _increaseMaxBatteryAmount) {
       _maximumBatteryPower += _increaseMaxBatteryAmount;
       _currentBatteryPower = _maximumBatteryPower;
    }

}
