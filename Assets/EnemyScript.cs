using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    float mass = 1.0f; // defines the character mass
    Vector3 impact = Vector3.zero;

    NavMeshAgent navMeshAgent;
    PlayerManager playerManager;

    [SerializeField] float punchForce = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(playerManager.gameObject.transform.position);

        // apply the impact force:
        if (impact.magnitude > 0.2) navMeshAgent.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerManager.AddImpact(other.gameObject.transform.position - transform.position, punchForce);
        }
    }

     // call this function to add an impact force:
    public void AddImpact(Vector3 dir,float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }
}
