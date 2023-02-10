using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField]
    private Transform moveToPosTransform;
    //public bool enemyIsDead;

    NavMeshAgent navMeshAgent;
    int amountOfLife;
    public TextMesh TextMesh;
    Vector3 startPos = new Vector3(0.1f, 0.9f, 13.64f);
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        amountOfLife = 4;
        TextMesh.text = amountOfLife.ToString();
        GameManager.Instance.enemyList.Add(gameObject);
    }

    void OnDestroy()
    {
        GameManager.Instance.OnEnemyDead(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = moveToPosTransform.position;
        if (amountOfLife == 0)
        {
            Instantiate(gameObject, startPos, gameObject.transform.localRotation);
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            if (amountOfLife > 0)
            {
                amountOfLife = amountOfLife - 1;
            }
            TextMesh.text = amountOfLife.ToString();
        }
    }
}
