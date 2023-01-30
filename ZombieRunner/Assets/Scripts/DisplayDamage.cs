using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float canvasDelay = 0.5f;
    void Start() {
        damageCanvas.enabled = false;  
    }
    public void DisplayCanvas(){
        damageCanvas.enabled = true;
        Invoke("DisableCanvas", canvasDelay);
    }
    void DisableCanvas(){
        damageCanvas.enabled = false;
    }
}
