using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerManager.AddImpact(other.gameObject.transform.position - transform.position, punchForce);
        }
    }

}
