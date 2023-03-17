using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
