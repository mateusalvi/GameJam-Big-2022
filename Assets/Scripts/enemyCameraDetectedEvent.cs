using SensorToolkit;
using SensorToolkit.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCameraDetectedEvent : MonoBehaviour
{
    [SerializeField] SecurityCamera securityCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(GameObject hit, Sensor sensor)
    {
        Debug.Log("Game Over");
        //securityCamera.SpotLight.color = securityCamera.AlarmColour;
        if (hit.CompareTag("Player")){
            securityCamera.StopAllCoroutines();
            securityCamera.StartCoroutine(securityCamera.alarmState());
        }
      
    }
}
