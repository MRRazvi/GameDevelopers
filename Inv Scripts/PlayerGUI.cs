using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{

    public float _returnMaximumBatteryPower;
    public float _returnCurrentBatteryPower;

    // public float _returnMaximumPlayerHealth;
    // public float _returnCurrentPlayerHealth;

    // public float _returnMaximumPlayerHunger;
    // public float _returnCurrentPlayerHunger;

    // public float _returnMaximumPlayerHydration;
    // public float _returnCurrentPlayerHydration;

    // public float _returnMaximumPlayerStamina;
    // public float _returnCurrentPlayerStamina;

    public float _batteryBarLength;
    // public float _healthBarLength;
    // public float _hungerBarLength;
    // public float _hydrationBarLength;
    // public float _staminaBarLength;

    public bool _displayGUI;

    private Vector2 _textureSize = new Vector2(175, 20);
    public Texture2D _backGroundTexture;
    public Texture2D _statBarMinTexture;
    public Texture2D _batteryBarMaxTexture;
    // public Texture2D _healthBarMaxTexture;
    // public Texture2D _hungerBarMaxTexture;
    // public Texture2D _hydrationBarMaxTexture;
    // public Texture2D _staminaBarMaxTexture;
    public GUISkin _myGUIHealthStyle;

    // Start is called before the first frame update
    void Start()
    {
        _displayGUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ToggleGUI")) {
            if(_displayGUI == false) {
                _displayGUI = true;
            }
            else {
                _displayGUI = false;
            }
        }
        if(_displayGUI == false)
        return;

        _returnCurrentBatteryPower = Flashlight._currentBatteryPower;
        _returnMaximumBatteryPower = Flashlight._maximumBatteryPower;

        // _returnCurrentPlayerHealth = PlayerHealth._currentPlayerHealth;
        // _returnMaximumPlayerHealth = PlayerHealth._maximumPlayerHealth;

        // _returnCurrentPlayerHunger = PlayerHealth._currentPlayerHunnger;
        // _returnMaximumPlayerHunger = PlayerHealth._maximumPlayerHunger;

        // _returnCurrentPlayerHydration = PlayerHealth._currentPlayerHydration;
        // _returnMaximumPlayerHydration = PlayerHealth._maximumPlayerHydration;

        // _returnCurrentPlayerStamina = PlayerHealth._currentPlayerStamina;
        // _returnMaximumPlayerStamina = PlayerHealth._maximumPlayerStamina;

        _batteryBarLength = (_returnCurrentBatteryPower / _returnMaximumBatteryPower);
        // _healthBarLength = (_returnCurrentPlayerHealth / _returnMaximumPlayerHealth);
        // _hungerBarLength = (_returnCurrentPlayerHunger / _returnMaximumPlayerHunger);
        // _hydrationBarLength = (_returnCurrentPlayerHydration / _returnMaximumPlayerHydration);
        // _staminaBarLength = (_returnCurrentPlayerStamina / _returnMaximumPlayerStamina);
    }
    void OnGUI() {
        GUI.skin = _myGUIHealthStyle;
        if(_displayGUI == true) {
          GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
           GUI.DrawTexture(new Rect(2.5f, 2.5f, _textureSize.x + 5, _textureSize.y + 5), _backGroundTexture);
        //   GUI.DrawTexture(new Rect(Screen.width/4 - (_textureSize.x / 4), 2.5f, _textureSize.x + 5, _textureSize.y + 5), _backGroundTexture);
        //   GUI.DrawTexture(new Rect(Screen.width/2 - (_textureSize.x / 2) - 2.5f, 2.5f, _textureSize.x + 5, _textureSize.y + 5), _backGroundTexture);
        //   GUI.DrawTexture(new Rect((Screen.width) - (Screen.width/4) - (_textureSize.x/1.33f) -5, 2.5f, _textureSize.x + 5, _textureSize.y + 5), _backGroundTexture);
        //   GUI.DrawTexture(new Rect(Screen.width - _textureSize.x - 7.5f, 2.5f, _textureSize.x + 5, _textureSize.y + 5), _backGroundTexture);
          GUI.EndGroup();

          GUI.BeginGroup(new Rect(5, 5, _textureSize.x, _textureSize.y));
          GUI.DrawTexture(new Rect(0, 0, _textureSize.x, _textureSize.y), _statBarMinTexture);
          GUI.DrawTexture(new Rect(0, 0, _textureSize.x * _batteryBarLength, _textureSize.y), _batteryBarMaxTexture);
          GUI.Label(new Rect(0, 0, _textureSize.x, _textureSize.y), "Battery: " + (int)_returnCurrentBatteryPower + "/" + _returnMaximumBatteryPower);
          GUI.EndGroup();

        //   GUI.BeginGroup(new Rect(Screen.width/4 - (_textureSize.x / 4) + 2.5f, 5f, _textureSize.x, _textureSize.y));
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x, _textureSize.y), _statBarMinTexture);
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x * _healthBarLength, _textureSize.y), _healthBarMaxTexture);
        //   GUI.Label(new Rect(0, 0, _textureSize.x, _textureSize.y), "Health: " + (int)_returnCurrentPlayerHealth + "/" + _returnMaximumPlayerHealth);
        //   GUI.EndGroup();

        //   GUI.BeginGroup(new Rect(Screen.width/2 - (_textureSize.x / 2), 5f, _textureSize.x, _textureSize.y));
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x, _textureSize.y), _statBarMinTexture);
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x * _hungerBarLength, _textureSize.y), _hungerBarMaxTexture);
        //   GUI.Label(new Rect(0, 0, _textureSize.x, _textureSize.y), "Hunger: " + (int)_returnCurrentPlayerHunger + "/" + _returnMaximumPlayerHunger);
        //   GUI.EndGroup();

        //   GUI.BeginGroup(new Rect((Screen.width) - (Screen.width/4) - (_textureSize.x/1.33f) - 2.5f, 5f, _textureSize.x, _textureSize.y));
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x, _textureSize.y), _statBarMinTexture);
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x * _staminaBarLength, _textureSize.y), _staminaBarMaxTexture);
        //   GUI.Label(new Rect(0, 0, _textureSize.x, _textureSize.y), "Stamina: " + (int)_returnCurrentPlayerStamina + "/" + _returnMaximumPlayerStamina);
        //   GUI.EndGroup();

        //   GUI.BeginGroup(new Rect(Screen.width - _textureSize.x - 5f, 5f, _textureSize.x, _textureSize.y));
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x, _textureSize.y), _statBarMinTexture);
        //   GUI.DrawTexture(new Rect(0, 0, _textureSize.x * _hydrationBarLength, _textureSize.y), _hydrationBarMaxTexture);
        //   GUI.Label(new Rect(0, 0, _textureSize.x, _textureSize.y), "Hydration: " + (int)_returnCurrentPlayerHydration + "/" + _returnMaximumPlayerHydration);
        //   GUI.EndGroup();
        }
    }
}
