using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float mass = 1.0f; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    [SerializeField] GameObject ViewModel;
 
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // call this function to add an impact force:
    public void AddImpact(Vector3 dir,float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }

    public void disablePlayer(){
        GetComponent<CharacterController>().enabled = false;
        GetComponent<playerMovementController>().enabled = false;
        GetComponent<CharacterShooting>().enabled = false;
        GetComponent<HUDcontroller>().enabled = false;
        ViewModel.SetActive(false);
    }

    public void enablePlayer(){
        GetComponent<CharacterController>().enabled = true;
        GetComponent<playerMovementController>().enabled = true;
        GetComponent<CharacterShooting>().enabled = true;
        GetComponent<HUDcontroller>().enabled = true;
        ViewModel.SetActive(true);
    }

    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}
