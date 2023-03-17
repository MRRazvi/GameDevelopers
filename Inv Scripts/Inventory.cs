using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Texture2D _inventoryBackground;

    public int _startLabelHorizontal = 200;
    public int _startLabelVertical = 25;

    public float _raycastLength = 2.5f;
    public bool _inventoryIsOpen;  

    private bool _batteryInView;


     private bool _batteryBoostInView;


    private GameObject _selectedBattery;


    private GameObject _selectedBatteryBoost;


    public static float _returnMaximumBatteryPower;
    public static float _returnCurrentBatteryPower;


    public int _batteriesInInventory;
 

     public int _batteryBoostsInInventory;


    public int _batteryPowerAmount=25;

     public int _batteryBoostAmount=25;


    public AudioClip _useBatteryAudio;
    public AudioClip _useBatteryBoostAudio;
    public AudioClip _batteryPickUpAudio;
    public AudioClip _batteryBoostPickUpAudio;


    
    public Texture2D _inventoryBoxTexture;
    public GUISkin _inventoryGUIStyle;

    private InventoryState _is;
    private enum InventoryState {
        InventoryReady = 0,
        InventoryOpen = 1,
        InventoryClosed = 2
    }

        void Awake() {
            _batteriesInInventory = 4;

            _batteryBoostsInInventory = 4;

        }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("InventoryStates");
        _inventoryIsOpen = false;
        _batteryInView = false;


        _batteryBoostInView = false;


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    

    // Update is called once per frame
    void Update()
    {
        if(_inventoryIsOpen == false)
        return;
         _returnCurrentBatteryPower = Flashlight._currentBatteryPower;
        _returnMaximumBatteryPower = Flashlight._maximumBatteryPower;


    }
    private IEnumerator InventoryStates() {
        while(true) {
            switch(_is) {
                case InventoryState.InventoryReady:
                InventoryReady();
                break;
                case InventoryState.InventoryOpen:
                InventoryOpen();
                break;
                case InventoryState.InventoryClosed:
                InventoryClosed();
                break;
            }
            yield return null;
        }
    }
    private void InventoryReady() {
        Debug.Log("InventoryReady");
        if(Input.GetKeyDown("i"))
        _is = InventoryState.InventoryOpen;

        RaycastHit _hit;
        Ray _ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit, _raycastLength)){
            //Replemish packs
            if(_hit.collider.tag == "Battery"){
                _selectedBattery = _hit.collider.gameObject;
                _batteryInView = true;
            }


  
            if(_hit.collider.tag == "BatteryBoost"){
                _selectedBatteryBoost = _hit.collider.gameObject;
                _batteryBoostInView = true;
            }
 
        }
        else {
           _batteryInView = false;
  
           _batteryBoostInView = false;

        }
    }

    private void InventoryOpen() {
        Debug.Log("InventoryOpen");
         if(Input.GetKeyDown("i"))
        _is = InventoryState.InventoryClosed;

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(_inventoryIsOpen == true)
        return;

        MonoBehaviour[] _myScripts = gameObject.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour script in _myScripts) {
            script.enabled = false;
        }
        MonoBehaviour[] _myScriptsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>();
        foreach(MonoBehaviour script in _myScriptsInChildren) {
            script.enabled = false;
    }
         GameObject.FindWithTag("Player").GetComponent<Inventory>().enabled = true;
         _inventoryIsOpen = true;
    }

    private void InventoryClosed() {
        Debug.Log("InventoryClosed");

          _inventoryIsOpen = false;
         Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

          MonoBehaviour[] _myScripts = gameObject.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour script in _myScripts) {
            script.enabled = true;
        }
        MonoBehaviour[] _myScriptsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>();
        foreach(MonoBehaviour script in _myScriptsInChildren) {
            script.enabled = true;
    }
         _is = InventoryState.InventoryReady;
    }
    void OnGUI() {
       GUI.skin = _inventoryGUIStyle;

       if(_inventoryIsOpen == true) {
           

           GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), _inventoryBackground);
           GUI.Label(new Rect(Screen.width/2 - (_startLabelHorizontal/2),5,_startLabelHorizontal,_startLabelVertical), "INVENTORY STATS");
            GUI.Label(new Rect(5,35,_startLabelHorizontal,_startLabelVertical), "Battery:" + (int)_returnCurrentBatteryPower + "/" + _returnMaximumBatteryPower);

           GUI.Label(new Rect(5,80,_startLabelHorizontal,_startLabelVertical), "CONSUMABLES");

           //Draw box textures behind consumables
           GUI.DrawTexture(new Rect(5, 105, _startLabelHorizontal, 30), _inventoryBoxTexture);

           //Display the player consumables in inventory
           GUI.Label(new Rect(5,110,_startLabelHorizontal,_startLabelVertical), "Batteries:" + _batteriesInInventory);
 

           //Write constitution boosts at top left of screen just below consumables
           GUI.Label(new Rect(5,275,_startLabelHorizontal,_startLabelVertical), "CONSTITUTION");

           //Draw box textures behind constitution
           GUI.DrawTexture(new Rect(5, 300, _startLabelHorizontal, 30), _inventoryBoxTexture);

           //Display the player consumables in inventory
           GUI.Label(new Rect(5,305,_startLabelHorizontal,_startLabelVertical), "Battery Boost:" + _batteryBoostsInInventory);


        //Create use buttons for consumables
        if(GUI.Button(new Rect(_startLabelHorizontal + 10,110,_startLabelHorizontal/2,_startLabelVertical - 5), "Use")) {
            AddBatteryToFlashlight();
        }


        // }

        //Create use buttons for constitution boosts
        if(GUI.Button(new Rect(_startLabelHorizontal + 10,305,_startLabelHorizontal/2,_startLabelVertical - 5), "Use")) {
            UseBatteryBoost();
        }


       }

       if(_batteryInView == true) {
        GUI.Label(new Rect(Screen.width/2,Screen.height/2,_startLabelHorizontal,_startLabelVertical), "Battery Pick Up?");
        if(Input.GetKeyDown("e"))   
        _selectedBattery.SendMessage("PickUpBattery", SendMessageOptions.DontRequireReceiver);
        
       }


        if(_batteryBoostInView == true) {
        GUI.Label(new Rect(Screen.width/2,Screen.height/2,_startLabelHorizontal,_startLabelVertical), "Battery Boost Pick Up?");
        if(Input.GetKeyDown("e"))
        _selectedBatteryBoost.SendMessage("PickUpBatteryBoost", SendMessageOptions.DontRequireReceiver);
        
       }

    }
    

    public void BatteryToInventory(int _addBatteriesToInventory) {
      Debug.Log("BatteryToInventory");

      _batteriesInInventory += _addBatteriesToInventory;
      GetComponent<AudioSource>().PlayOneShot(_batteryPickUpAudio);
    }
    public void AddBatteryToFlashlight() {
      Debug.Log("AddBatteryToFlashlight");

      if(_batteriesInInventory == 0)
      return;

      if(_returnCurrentBatteryPower == _returnMaximumBatteryPower)
      return;

      GetComponent<AudioSource>().PlayOneShot(_useBatteryAudio);
      _batteriesInInventory -= 1;
      GameObject.Find ("Spotlight").GetComponent<Flashlight>().enabled = true;
      Flashlight temp = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Flashlight>();
      temp.AddBattery(_batteryPowerAmount);
      GameObject.Find ("Spotlight").GetComponent<Flashlight>().enabled = false;
    }

     public void BatteryBoostToInventory(int _addBatteryBoostToInventory) {
        Debug.Log("BatteryBoostToInventory");
       _batteryBoostsInInventory += _addBatteryBoostToInventory;
       GetComponent<AudioSource>().PlayOneShot(_batteryBoostPickUpAudio);
    }

    void UseBatteryBoost() {
      Debug.Log("UseBatteryBoost");

      if(_batteryBoostsInInventory == 0)
      return;

      GetComponent<AudioSource>().PlayOneShot(_useBatteryBoostAudio);
      _batteryBoostsInInventory -= 1;
      GameObject.Find("Spotlight").GetComponent<Flashlight>().enabled = true;
      Flashlight temp = GameObject.Find("Spotlight").GetComponentInChildren<Flashlight>();
      temp.IncreaseMaxBattery(_batteryBoostAmount);
      GameObject.Find("Spotlight").GetComponent<Flashlight>().enabled = false;
    }

}
