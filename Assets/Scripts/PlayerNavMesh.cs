using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField]
    //private Transform moveToPosTransform;
    //public bool enemyIsDead;

    NavMeshAgent navMeshAgent;
    public int amountOfLife;
    public TextMesh TextMesh;
    Vector3 startPos = new Vector3(12.53f, 0, 11.94f);
    Vector3 destination=new Vector3(14.8f,0.15f,-15.71f);
    public int EnemyMoney;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        TextMesh.text = amountOfLife.ToString();
        GameManager.Instance.enemyList.Add(gameObject);
    }

    void OnDestroy()
    {
        GameManager.Instance.OnEnemyDead(gameObject,EnemyMoney);

    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.destination = destination;
        if (amountOfLife <= 0&&(!gameObject.IsDestroyed()))
        {
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            if (amountOfLife > 0)
            {
                amountOfLife = amountOfLife - other.gameObject.GetComponent<MissileMovement>().damage;
            }
            TextMesh.text = amountOfLife.ToString();
        }
    }
}
