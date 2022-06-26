using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float mass = 1.0f; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    [SerializeField] GameObject gunModel;

    bool isEnabled = true;

    [SerializeField] GameObject hudPointerGun;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // call this function to add an impact force:
    public void AddImpact(Vector3 dir,float force)
    {
        if (isEnabled)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
            impact += dir.normalized * force / mass;
        }
    }

    public void DisablePlayer(){
        GetComponent<Collider>().isTrigger = true;
        GetComponent<playerMovementController>().enabled = false;
        GetComponent<CharacterShooting>().enabled = false;
        hudPointerGun.SetActive(false);
        gunModel.SetActive(false);
        isEnabled = false;
    }

    public void EnablePlayer(){
        GetComponent<Collider>().isTrigger = false;
        GetComponent<playerMovementController>().enabled = true;
        GetComponent<CharacterShooting>().enabled = true;
        hudPointerGun.SetActive(true);
        gunModel.SetActive(true);
        isEnabled = true;
    }

    void Update()
    {
        if (isEnabled)
        {
            // apply the impact force:
            if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

            if(transform.position.y < -20)
            {
                FindObjectOfType<GameManager>().RestartScreen();
            }
        }
    }
}
