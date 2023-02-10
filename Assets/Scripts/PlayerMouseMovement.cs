using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMouseMovement : MonoBehaviour
{
    NavMeshAgent agent;
    int amountOfLife;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        amountOfLife = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                agent.SetDestination(hitPoint.point);
            }
        }
        if (amountOfLife == 0)
        {
            Destroy(gameObject);

        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            amountOfLife = amountOfLife - 1;
        }
    }

}
