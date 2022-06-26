using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float health;

    private bool isAlive;

    [SerializeField] Slider healthUI;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;

        if (healthUI != null)
        {
            healthUI.maxValue = health;
            healthUI.value = health;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (healthUI != null)
        {
            healthUI.value = health;
        }

        if (health <= 0){
            killCharacter();
        }
    }

    private void killCharacter()
    {
        isAlive = false;
        Destroy(gameObject);
    }
}
