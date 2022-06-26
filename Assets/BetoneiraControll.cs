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
        if (canInteract || working)
        {
            if (Input.GetKeyDown(KeyCode.E) && !working)
            {
                Mount();
            }
            else if(Input.GetKeyDown(KeyCode.E) && working)
            {
                Drop();
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
        verticalAxisBase.transform.Rotate((Input.GetAxisRaw("Mouse Y") * rotationSpeed), 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            player.GetComponent<HUDcontroller>().showInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
            player.GetComponent<HUDcontroller>().hideInteraction();
        }
    }

    void Mount()
    {
        working = true;
        player.transform.SetParent(verticalAxisBase.transform);
        player.GetComponent<PlayerManager>().DisablePlayer();

        player.transform.position = playerSeat.position;
        player.transform.rotation = playerSeat.rotation;
    }

    void Drop()
    {
        working = false;

        player.transform.position = playerOutPos.position;
        player.transform.rotation = playerOutPos.rotation;

        player.transform.SetParent(null);

        player.GetComponent<PlayerManager>().EnablePlayer();

        verticalAxisBase.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        player.GetComponent<HUDcontroller>().hideInteraction();
        canInteract = false;
    }

    public void playShotSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Guns/shot_concrete_mixer");
    }
}
