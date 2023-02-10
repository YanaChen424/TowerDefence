using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Tower;

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

    public List<GameObject> enemyList = new List<GameObject> ();
    public List<GameObject> towerList = new List<GameObject>(3);


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
                    }
                }
                else if (towerList[1].name == towerNameButton)
                {
                    if (bankAccountCalc >= 4)
                    {
                        Instantiate(towerList[1], hitPoint.point, towerList[1].transform.localRotation);
                        bankAccountCalc -= 4;
                        bankAccount.text = bankAccountCalc.ToString();
                    }
                }
                else if (towerList[2].name == towerNameButton)
                {
                    if (bankAccountCalc >= 5)
                    {
                        Instantiate(towerList[2], hitPoint.point, towerList[2].transform.localRotation);
                        bankAccountCalc -= 5;
                        bankAccount.text = bankAccountCalc.ToString();
                    }
                }
            }
        }
        if (towerNameButton != null)
        {
            print(towerNameButton);
        }

    }
    public void OnEnemyDead(GameObject enemy) // looks good! :)
    {
        enemyList.Remove(enemy);
        enemyCount++;
        bankAccountCalc += 2;
        bankAccount.text = bankAccountCalc.ToString();
    }
}
