using UnityEngine;

public class Round : MonoBehaviour {
    
    public float damage;
    public float pushForce;
    public float destroyTime= 1f;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemy = other.gameObject.GetComponent<EnemyScript>();
            enemy.AddImpact(transform.position - player.gameObject.transform.position, pushForce * damage);

        }
    }
}
