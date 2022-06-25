using UnityEngine;

public class Round : MonoBehaviour {
    public float damage;
    public float destroyTime;


    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        
    }

    /*
    void OnCollisionEnter(Collision other) {
        Target target = other.gameObject.GetComponent<Target>();
        // Only attempts to inflict damage if the other game object has
        // the 'Target' component
        if(target != null) {
            target.Hit(damage);
            Destroy(gameObject); // Deletes the round
        }
        Destroy(gameObject);
    }
    */
}