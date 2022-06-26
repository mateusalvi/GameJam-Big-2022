using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    float mass = 1.0f; // defines the character mass
    [SerializeField] private float damage;
    Vector3 impact = Vector3.zero;

    NavMeshAgent navMeshAgent;
    PlayerManager playerManager;

    [SerializeField] float punchForce = 50.0f;
    [SerializeField] float punchInterval = 1f;

    [SerializeField] Animator anim;

    float timeToPunch;

    float timeToAwake;
    float awakeTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        timeToAwake = Time.time + awakeTime;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToAwake)
        {
            navMeshAgent.SetDestination(playerManager.gameObject.transform.position);

            anim.SetBool("isWalk", true);
            // apply the impact force:
            if (impact.magnitude > 0.2) navMeshAgent.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time > timeToPunch)
        {
            playerManager.AddImpact(other.gameObject.transform.position - transform.position, punchForce);
            other.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
            timeToPunch = Time.time + punchInterval;
        }
    }

    // call this function to add an impact force:
    public void AddImpact(Vector3 dir,float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }

    public void PlayTookDamageSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/hurt");
    }
}
