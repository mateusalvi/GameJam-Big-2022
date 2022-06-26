using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDcontroller : MonoBehaviour
{
    [SerializeField] private Text currentAmmoText;
    [SerializeField] private Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmoText.text = gun.GetRemaningAmmunition().ToString();
    }

}
