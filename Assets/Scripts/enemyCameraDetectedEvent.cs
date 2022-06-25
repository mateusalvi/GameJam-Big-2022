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

    public void GameOver()
    {
        Debug.Log("Game Over");
        securityCamera.SpotLight.color = securityCamera.AlarmColour;
        //gameObject.Find("SecurityCamera").GetComponent<SecurityCamera>().StartCoroutine(alarmState());
    }
}
