using UnityEngine;

public class Round : MonoBehaviour {
    
    public float damage;
    public float pushForce;
    public float destroyTime;
    private bool alreadyDamaged = false;
    Rigidbody rb;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, destroyTime);
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(rb.velocity.y <= 2 && rb.velocity.x <= 2 && rb.velocity.z <= 2)
        {
            alreadyDamaged = true;
        }
    }


    void OnCollisionEnter(Collision other) {
        // CharacterStats target = other.gameObject.GetComponent<CharacterStats>();
        // Only attempts to inflict damage if the other game object has
        // the 'Target' component
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !alreadyDamaged)
        {
            EnemyScript enemy = other.gameObject.GetComponent<EnemyScript>();
            enemy.AddImpact(transform.position - player.gameObject.transform.position, pushForce * damage);
            other.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
            alreadyDamaged = true;
        }
    }
}
