using UnityEngine;

public class CharacterShooting : MonoBehaviour {
    public Gun gun;

    public int shootButton;
    public KeyCode reloadKey;

    void Update() {
        if(Input.GetMouseButton(shootButton)) {
            gun.Shoot();
        }

        if(Input.GetKeyDown(reloadKey)) {
            gun.Reload();
        }
    }

    public void playShotSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Guns/shot_brick");
    }
}