using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject prefab;

    void Start()
    {
        // Initialize walkable ground nav mesh 
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Move the player to the mouse position
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                //gameObject.GetComponent<NavMeshAgent>().speed = 8.2f;
                agent.SetDestination(hit.point);

                // Mouse position ripple effect
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //gameObject.GetComponent<NavMeshAgent>().speed = 0f;
    }
}