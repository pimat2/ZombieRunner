using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 60f;
    [SerializeField] float intensityAmount = 3f;
    FlashLightSystem flashLightSystem;
    // Start is called before the first frame update
    void Start()
    {
        flashLightSystem = FindObjectOfType<FlashLightSystem>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            flashLightSystem.RestoreLightAngle(restoreAngle);
            flashLightSystem.RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
