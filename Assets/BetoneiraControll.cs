using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetoneiraControll : MonoBehaviour
{
    [SerializeField] GameObject verticalAxisBase;
    [SerializeField] GameObject shootingPoint;

    [SerializeField] Transform playerSeat;

    [SerializeField] Transform playerOutPos;

    [SerializeField] Transform betoneiraBase;

    [SerializeField] Gun betoneiraGun;

    [SerializeField] float rotationSpeed = 1f;

    bool canInteract = false;

    GameObject player;

    bool working = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E) && !working)
            {
                working = true;
                player.transform.SetParent(verticalAxisBase.transform);
                player.GetComponent<Collider>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<playerMovementController>().enabled = false;
                player.GetComponent<CharacterShooting>().enabled = false;
                player.transform.position = playerSeat.position;
                player.transform.rotation = playerSeat.rotation;
            }
            else if(Input.GetKeyDown(KeyCode.E) && working)
            {
                working = false;

                player.transform.position = playerOutPos.position;
                player.transform.rotation = playerOutPos.rotation;

                player.transform.SetParent(null);
               
                player.GetComponent<Collider>().enabled = true;
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<playerMovementController>().enabled = true;
                player.GetComponent<CharacterShooting>().enabled = true;

                verticalAxisBase.transform.rotation = new Quaternion(0f, 0f, 0f,0f);
            }
        }

        if (working) {
            //Run some animation of barrel rotating
            MoveBetoneira();

            if (Input.GetMouseButtonDown(0))
            {
                ShootBetoneira();
            }
        }
    }

    void ShootBetoneira()
    {
        betoneiraGun.Shoot();
    }

    private void MoveBetoneira()
    {
        transform.Rotate(0f, (Input.GetAxisRaw("Mouse X") * rotationSpeed), 0f);
        if(verticalAxisBase.transform.rotation.x > -70 && verticalAxisBase.transform.rotation.x < 80)
        {
            verticalAxisBase.transform.Rotate((Input.GetAxisRaw("Mouse Y") * rotationSpeed), 0f, 0f);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
      
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }
}
