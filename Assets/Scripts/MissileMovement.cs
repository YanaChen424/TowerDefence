using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public GameObject TargetEnemy;
    public bool startFire;

    //Transform Enemy;
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.Find("Enemy").GetComponent<Transform>();
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetEnemy != null)
        {
            if (TargetEnemy.IsDestroyed())
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetEnemy.transform.position, Time.deltaTime * 10);
            }
        }
        else
        {
            if (startFire)
            {
                Destroy(gameObject);
            }
        }
    }
}
