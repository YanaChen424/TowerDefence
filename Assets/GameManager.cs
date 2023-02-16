using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public string towerNameButton;


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
    public GameObject SourceMarker;
    public GameObject TargetMarker;

    public List<GameObject> enemyList = new List<GameObject> ();
    public List<GameObject> towerList = new List<GameObject>();
    public List<GameObject> enemyTypeList = new List<GameObject>();

    Vector3 startPos = new Vector3(22.99327f, 9.918213e-05f, -2.19f);
    //PlayerNavMesh enemyIsDead;
    public int enemyCount;
    //int towerCount;

    public TextMeshProUGUI bankAccount;
    int bankAccountCalc;

    public GameObject upgradePanel;

    GameObject towerColliderSell;
    string CannonSellType;

    public int enemyReachTargetNum;


    // Start is called before the first frame update
    void Start()
    {
        startPos = SourceMarker.transform.position;
        enemyCount = 0;
        bankAccountCalc = 2;
        bankAccount.text = "Bank:" + bankAccountCalc.ToString();
        

    }

    private void Awake()
    {
        _instance = this;
    }

    private bool IsOverMenuBars()
    {
        int uiLayer = 5;

        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[0].gameObject.layer == uiLayer)
                return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint) && hitPoint.collider.CompareTag("placement") && !IsOverMenuBars() && towerNameButton !=null)
            {
                if (towerList[0].name == towerNameButton)
                {
                    if (bankAccountCalc >= 2)
                    {
                        Instantiate(towerList[0], hitPoint.point, towerList[0].transform.localRotation);
                        bankAccountCalc -= 2;
                        bankAccount.text = "Bank:" + bankAccountCalc.ToString();
                        towerNameButton = null;
                    }
                }
                else if (towerList[1].name == towerNameButton)
                {
                    if (bankAccountCalc >= 4)
                    {
                        Instantiate(towerList[1], hitPoint.point, towerList[1].transform.localRotation);
                        bankAccountCalc -= 4;
                        bankAccount.text = "Bank:" + bankAccountCalc.ToString();
                        towerNameButton = null;
                    }
                }
                else if (towerList[2].name == towerNameButton)
                {
                    if (bankAccountCalc >= 5)
                    {
                        Instantiate(towerList[2], hitPoint.point, towerList[2].transform.localRotation);
                        bankAccountCalc -= 5;
                        bankAccount.text = "Bank:" + bankAccountCalc.ToString();
                        towerNameButton = null;
                    }
                }
                
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint) && hitPoint.collider.CompareTag("Tower")&& hitPoint.collider.gameObject != null)
            {
                upgradePanel.SetActive(true);
                towerColliderSell = hitPoint.collider.gameObject;
                CannonSellType=towerColliderSell.GetComponentInChildren<CannonEngine>().CannonSellType;
                print(CannonSellType);
                print(towerColliderSell.name);
                

            }
        }

        if (Time.time - CreateTime >= 2&&Time.time<30)
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

    public void upgrade()
    {
        print("upgrade");
        if (CannonSellType == towerList[0].name)
        {
            bankAccountCalc -= 2;
            bankAccount.text = bankAccountCalc.ToString();
            print(bankAccount.text);
            Vector3 upgradedTowerPos=new Vector3();
            upgradedTowerPos=towerColliderSell.transform.position;
            if (towerColliderSell != null)
                Destroy(towerColliderSell);
            Instantiate(towerList[1], upgradedTowerPos, towerList[1].transform.localRotation);


        }
        else if (CannonSellType == towerList[1].name)
        {
            bankAccountCalc -= 5;
            bankAccount.text = bankAccountCalc.ToString();
            print(bankAccount.text);
            Vector3 upgradedTowerPos = new Vector3();
            upgradedTowerPos = towerColliderSell.transform.position;
            if (towerColliderSell != null)
                Destroy(towerColliderSell);
            Instantiate(towerList[2], upgradedTowerPos, towerList[1].transform.localRotation);


        }
        else if (CannonSellType == towerList[2].name)
        {
            print("not upgradeable");
        }
        upgradePanel.SetActive(false);
    }


    public void Sell()
    {
        print("sell");
        if (CannonSellType == towerList[0].name)
        {
            bankAccountCalc += 2;
            bankAccount.text = bankAccountCalc.ToString();
            print(bankAccount.text);
            

        }
        else if (CannonSellType == towerList[1].name)
        {
            bankAccountCalc += 4;
            bankAccount.text = bankAccountCalc.ToString();
            print(bankAccount.text);


        }
        else if (CannonSellType == towerList[2].name)
        {
            bankAccountCalc += 5;
            bankAccount.text = bankAccountCalc.ToString();
            print(bankAccount.text);
            


        }
        upgradePanel.SetActive(false);
        if (towerColliderSell!=null)
        Destroy(towerColliderSell);
    }

    public void OnEnemyDead(GameObject enemy,int enemyMoney) 
    {
        enemyList.Remove(enemy);
        enemyCount++;
        bankAccountCalc += enemyMoney;
;
        bankAccount.text = "Bank:" + bankAccountCalc.ToString();
    }

    public void enemyReachTarget()
    {
        enemyReachTargetNum++;
        if(enemyReachTargetNum == 4)
        {
            FindObjectOfType<SceneMenager>().Lose();
        }
    }
}
