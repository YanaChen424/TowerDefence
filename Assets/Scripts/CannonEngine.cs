using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonEngine : MonoBehaviour
{
    //[SerializeField] Transform EnemyPos;
    [SerializeField] GameObject missile;
    [SerializeField] Transform ShootPoint;
    //public GameObject Enemy;
    float shootingTime;
    public string cannonType;
    public int towerDis;

    public string CannonSellType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var enemies = GameManager.Instance.enemyList;
        cannonType = GameManager.Instance.towerNameButton;
        for (int i = 0; i < enemies.Count; i++)
        {
          
            if (Vector3.Distance(transform.position, enemies[i].transform.position) <= towerDis)
            {
                transform.LookAt(enemies[i].transform.position);
                if ((Time.time - shootingTime >= 1))
                {
                        var newMissle = Instantiate(missile, ShootPoint.position, missile.transform.localRotation);
                        newMissle.GetComponent<MissileMovement>().TargetEnemy = enemies[i];
                        newMissle.GetComponent<MissileMovement>().startFire = true;
                        shootingTime = Time.time;
                        break;
                }
            }
            
        }

    }

}
