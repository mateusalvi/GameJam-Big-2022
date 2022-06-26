using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollect : MonoBehaviour
{
    public int AmmunitionValue;
    public int RotationSpeed;
    public float RespawnTime;
    public Vector3 UnactiveSize;
    private float nextRespawnTime;
    private Vector3 originalSize;


    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale;
        nextRespawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
        checkForRespawn();
    }

    private void Animation()
    {
        transform.Rotate(0, RotationSpeed*Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<CharacterShooting>().gun.giveRemaningAmmunition(AmmunitionValue);
            nextRespawnTime = Time.time + RespawnTime;
            transform.localScale = UnactiveSize;
        }
    }

    private void checkForRespawn()
    {
        if(Time.time >= nextRespawnTime)
        {
            GetComponent<Collider>().enabled = true;
            transform.localScale = originalSize;
        }
    }
}
