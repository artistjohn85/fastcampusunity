using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform targetPos;
    //[SerializeField] EnemyController[] enemyControllers; // ���� �����ϴ� ���, �ӵ��� ������.
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

        // ���������� ���� ������Ʈ�� ����.
        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject gameObject = Instantiate(enemyPrefab, this.gameObject.transform);
        //    EnemyController enemyController = gameObject.GetComponent<EnemyController>();
        //    enemyControllers.Add(enemyController);
        //    //enemyController.SetInit(targetPos);
        //}

        // ���� �����ϴ� ���, �ӵ��� ������. (���� ������ ���� �� �� �ִ�.)
        // [SerializeField] EnemyController[] enemyControllers; 

        // �� ��ġ���� �ڽĵ��� �˻��ؼ� �����´�.
        //enemyControllers = gameObject.GetComponentsInChildren<EnemyController>(true); // Ȱ��, ��Ȱ���� ������Ʈ �� ã�� �� ����, ����� ���� ���� �� �ִ�.
        // ��ũ��Ʈ �̸����� �˻�
        //enemyControllers = FindObjectsOfType<EnemyController>(); // ����� ����, ������ ������Ʈ�� ã�� �� �����ϴ�.
        // Tag�̸����� �˻�
        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy"); // ����� ����, ������ ������Ʈ�� ã�� �� �����ϴ�.
        //foreach (GameObject gameObject in gameObjects)
        //{
        //    enemyControllers.Add(gameObject.GetComponent<EnemyController>());
        //}

        // �̸� ���
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
