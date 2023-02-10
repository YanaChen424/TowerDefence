using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Tower;

    public static GameManager _instance;
    public static GameManager Instance
    {
        get {
            if (_instance == null)
                print("GameObject.Insatnce is nul!!!!!!!!");
            return _instance; 
        }
    }

    public List<GameObject> enemyList = new List<GameObject> ();


    //PlayerNavMesh enemyIsDead;
    public int enemyCount;
    //int towerCount;

    public TextMeshProUGUI bankAccount;
    public int bankAccountCalc;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        bankAccountCalc = 0;
        bankAccount.text = "0";

    }

    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                if (bankAccountCalc >= 5)
                {
                    Instantiate(Tower, hitPoint.point, Tower.transform.localRotation);
                    bankAccountCalc -= 5;
                    bankAccount.text = bankAccountCalc.ToString();
                }
            }
        }
        //for(int i = 0; i < enemyList.Count; i++)
        //{
        //    GameObject enemy = enemyList[i];
        //    enemyIsDead = enemy.GetComponent<PlayerNavMesh>();
        //    if (enemyIsDead.enemyIsDead)
        //    {
        //        print(enemyIsDead.enemyIsDead);
        //        enemyCount++;
        //        bankAccountCalc += 2;
        //        bankAccount.text=bankAccountCalc.ToString();
        //        //towerCount++;
        //        enemyIsDead.enemyIsDead = false;
        //    }
        //}

    }
    public void OnEnemyDead(GameObject enemy) // looks good! :)
    {
        enemyList.Remove(enemy);
        enemyCount++;
        bankAccountCalc += 2;
        bankAccount.text = bankAccountCalc.ToString();
    }
}
