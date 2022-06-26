using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float mass = 1.0f; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    [SerializeField] GameObject gunModel;

    [SerializeField] GameObject hudPointerGun;

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

    public void DisablePlayer(){
        GetComponent<Collider>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<playerMovementController>().enabled = false;
        GetComponent<CharacterShooting>().enabled = false;
        hudPointerGun.SetActive(false);
        gunModel.SetActive(false);
    }

    public void EnablePlayer(){
        GetComponent<Collider>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        GetComponent<playerMovementController>().enabled = true;
        GetComponent<CharacterShooting>().enabled = true;
        hudPointerGun.SetActive(true);
        gunModel.SetActive(true);
    }

    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}