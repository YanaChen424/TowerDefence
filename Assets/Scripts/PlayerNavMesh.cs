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

    Vector3 startPos;
    Vector3 destination;
    public int EnemyMoney;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = GameManager.Instance.SourceMarker.transform.position;
        destination = GameManager.Instance.TargetMarker.transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        TextMesh.text = amountOfLife.ToString();
        GameManager.Instance.enemyList.Add(gameObject);
        animator = GetComponent<Animator>();
        
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
            animator.SetBool("isDying", true);
            navMeshAgent.speed = 0;
            StartCoroutine(DisposeInDelay());
        }
    }

    IEnumerator DisposeInDelay()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
    IEnumerator HitInDelay()
    {
        yield return new WaitForSeconds(2);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            if (amountOfLife > 0)
            {
                amountOfLife = amountOfLife - other.gameObject.GetComponent<MissileMovement>().damage;
                animator.SetBool("isHit", true);
                navMeshAgent.speed--;
                StartCoroutine(HitInDelay());
            }
            TextMesh.text = amountOfLife.ToString();
        }
        if (other.gameObject.name== "TragetMarker")
        {
            GameManager.Instance.enemyReachTarget();
            Destroy(gameObject);


        }
    }
}
