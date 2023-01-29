using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [Header("Camera Zoom")]
    [SerializeField] float zoomedFOV = 35f;
    [SerializeField] float normalFOV = 60f;
    [Header("Mouse Sensitivity")]
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    void Update()
    {
        if(Input.GetMouseButton(1)){
            ZoomIn();
        }
        else{
           ZoomOut();
        }
        
    }
    void ZoomIn(){
        fpsCamera.fieldOfView = zoomedFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }
    void ZoomOut(){
        fpsCamera.fieldOfView = normalFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
    
}
