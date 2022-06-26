using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cimentoFrescoDebuff : MonoBehaviour
{
    public float speedDebuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<playerMovementController>().walkingSpeed = other.GetComponent<playerMovementController>().walkingSpeed-speedDebuff;
            other.GetComponent<playerMovementController>().runningSpeed = other.GetComponent<playerMovementController>().runningSpeed-speedDebuff;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<playerMovementController>().walkingSpeed = other.GetComponent<playerMovementController>().walkingSpeed+speedDebuff;
            other.GetComponent<playerMovementController>().runningSpeed = other.GetComponent<playerMovementController>().runningSpeed+speedDebuff;
        }
    }
}