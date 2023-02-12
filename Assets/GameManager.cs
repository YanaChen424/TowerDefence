using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public string towerNameButton;
    int firstTowerCount;
    int secondTowerCount;
    int thirdTowerCount;

    public static GameManager _instance;
    public static GameManager Instance
    {
        get {
            if (_instance == null)
                print("GameObject.Insatnce is nul!!!!!!!!");
            return _instance; 
        }
    }

    public float CreateTime { get; private set; }

    public List<GameObject> enemyList = new List<GameObject> ();
    public List<GameObject> towerList = new List<GameObject>();
    public List<GameObject> enemyTypeList = new List<GameObject>();

    Vector3 startPos = new Vector3(12.53f, 0, 11.94f);
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
            if (Physics.Raycast(ray, out hitPoint)&&hitPoint.collider.CompareTag("placement"))
            {
                if (towerList[0].name == towerNameButton)
                {
                    if (bankAccountCalc >= 2)
                    {
                        Instantiate(towerList[0], hitPoint.point, towerList[0].transform.localRotation);
                        bankAccountCalc -= 2;
                        bankAccount.text = bankAccountCalc.ToString();
                        firstTowerCount++;
                    }
                }
                else if (towerList[1].name == towerNameButton)
                {
                    if (bankAccountCalc >= 4)
                    {
                        Instantiate(towerList[1], hitPoint.point, towerList[1].transform.localRotation);
                        bankAccountCalc -= 4;
                        bankAccount.text = bankAccountCalc.ToString();
                        secondTowerCount++;
                    }
                }
                else if (towerList[2].name == towerNameButton)
                {
                    if (bankAccountCalc >= 5)
                    {
                        Instantiate(towerList[2], hitPoint.point, towerList[2].transform.localRotation);
                        bankAccountCalc -= 5;
                        bankAccount.text = bankAccountCalc.ToString();
                        thirdTowerCount++;
                    }
                }
            }
        }
        //else if(Input.GetMouseButtonDown(1))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitPoint;
        //    if (Physics.Raycast(ray, out hitPoint) && hitPoint.collider.CompareTag("Tower"))
        //    {
        //        if (towerList[0].name == towerNameButton)
        //        {
        //                bankAccountCalc += 2;
        //                bankAccount.text = bankAccountCalc.ToString();
        //                Destroy(towerList[0]);
                  
        //        }
        //        else if (towerList[1].name == towerNameButton)
        //        {
        //                bankAccountCalc += 4;
        //                bankAccount.text = bankAccountCalc.ToString();
        //                Destroy(towerList[1]);

        //        }
        //        else if (towerList[2].name == towerNameButton)
        //        {
        //                bankAccountCalc += 5;
        //                bankAccount.text = bankAccountCalc.ToString();
        //                Destroy(towerList[2]);

        //        }
        //    }
        //}
        //if (towerNameButton != null)
        //{
        //    print(towerNameButton);
        //}

        if(Time.time - CreateTime >= 2&&Time.time<30)
        {
            Instantiate(enemyTypeList[0],startPos, enemyTypeList[0].transform.localRotation);
            CreateTime = Time.time;
        }
        if (Time.time - CreateTime >= 2 && Time.time < 80 && Time.time >= 30)
        {
            Instantiate(enemyTypeList[0], startPos, enemyTypeList[0].transform.localRotation);
            Instantiate(enemyTypeList[1], startPos, enemyTypeList[0].transform.localRotation);
            CreateTime = Time.time;
        }
        if (Time.time - CreateTime >= 2 && Time.time < 120&& Time.time >= 80)
        {
            Instantiate(enemyTypeList[0], startPos, enemyTypeList[0].transform.localRotation);
            Instantiate(enemyTypeList[1], startPos, enemyTypeList[0].transform.localRotation);
            Instantiate(enemyTypeList[2], startPos, enemyTypeList[0].transform.localRotation);
            CreateTime = Time.time;
        }
    }
    public void OnEnemyDead(GameObject enemy,int enemyMoney) // looks good! :)
    {
        enemyList.Remove(enemy);
        enemyCount++;
        bankAccountCalc += enemyMoney;
;
        bankAccount.text = bankAccountCalc.ToString();
    }
}
