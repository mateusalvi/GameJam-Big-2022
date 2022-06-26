using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float health;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if(health <= 0){
            killCharacter();
        }
    }

    private void killCharacter()
    {
        isAlive = false;
        Destroy(gameObject);
    }
}
