using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform targetPos;
    //[SerializeField] EnemyController[] enemyControllers; // 직접 연결하는 경우, 속도가 빠르다.
    private List<EnemyController> enemyControllers = new List<EnemyController>(); // cache
    public List<EnemyController> Enemies
    {
        get
        {
            return enemyControllers;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);

        // 프리팹으로 적군 오브젝트를 생성.
        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject gameObject = Instantiate(enemyPrefab, this.gameObject.transform);
        //    EnemyController enemyController = gameObject.GetComponent<EnemyController>();
        //    enemyControllers.Add(enemyController);
        //    //enemyController.SetInit(targetPos);
        //}

        // 직접 연결하는 경우, 속도가 빠르다. (순서 꼬임을 방지 할 수 있다.)
        // [SerializeField] EnemyController[] enemyControllers; 

        // 내 위치에서 자식들을 검색해서 가져온다.
        //enemyControllers = gameObject.GetComponentsInChildren<EnemyController>(true); // 활성, 비활성된 오브젝트 다 찾을 수 있음, 비용은 조금 낮을 수 있다.
        // 스크립트 이름으로 검색
        //enemyControllers = FindObjectsOfType<EnemyController>(); // 비용이 높고, 숨겨진 오브젝트는 찾을 수 없습니다.
        // Tag이름으로 검색
        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy"); // 비용이 높고, 숨겨진 오브젝트는 찾을 수 없습니다.
        //foreach (GameObject gameObject in gameObjects)
        //{
        //    enemyControllers.Add(gameObject.GetComponent<EnemyController>());
        //}

        // 이름 출력
        //foreach (EnemyController controller in enemyControllers)
        //{
        //    Debug.Log(controller.gameObject.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void AttackAll()
    //{
    //    foreach (EnemyController controller in enemyControllers)
    //    {
    //        controller.Attack();
    //    }
    //}
}
