using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using mozaAPI;
using static mozaAPI.mozaAPI;

public class MozaController : MonoBehaviour
{
    private HidDevice hid_device;
    private HIDData hid_data;
    private ERRORCODE errorcode;

    // Start is called before the first frame update
    void Start(){
        installMozaSDK();
    }

    public void Setup(){
        hid_device = new HidDevice();
    }

    // Update is called once per frame
    void Update(){
        try{
            hid_data = getHIDData(ref errorcode);
        }
        catch(Exception ex){
            Debug.Log($"HIDData error:{ex}");
            return;
        }
        
    }

    void OnApplicationQuit(){
        removeMozaSDK();
    }

    public float GetSteeringAngle(){
        return hid_data.fSteeringWheelAngle;
    }
}
