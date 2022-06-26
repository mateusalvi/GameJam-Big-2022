using UnityEngine;

public class Round : MonoBehaviour {
    
    public float damage;
    public float pushForce;
    public float destroyTime;
    public float initialRotationForce;
    private bool alreadyDamaged = false;
    Rigidbody rb;
    GameObject player;

    private void Start()
    {
        Vector3 torque = new Vector3 (initialRotationForce*(float)Random.Range(0f,10f), initialRotationForce*(float)Random.Range(0f,10f), initialRotationForce*(float)Random.Range(0f,10f));
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, destroyTime);
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(torque, ForceMode.Force);
    }


    void Update()
    {
        if(rb.velocity.y <= 1 && rb.velocity.x <= 1 && rb.velocity.z <= 1)
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
