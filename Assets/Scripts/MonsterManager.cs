using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private GameObject monsterAPrefab;
    [SerializeField] private GameObject monsterBPrefab;
    [SerializeField] private Transform monsterParent;

    private ObjectPoolManager objectPoolManager; // cache

    //private List<MonsterA> monsterAs = new List<MonsterA>();

    void Start()
    {
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject obj = objectPoolManager.GetObjectByPrefab(monsterAPrefab, monsterParent, Vector3.zero, Quaternion.identity);
            //Debug.Log(obj.GetHashCode());
            // MonsterA[] monsterAs = monsterParent.GetComponentsInChildren<MonsterA>(true);

            //bool isFound = false;
            //foreach (var item in monsterAs)
            //{
            //    if (!item.gameObject.activeInHierarchy)
            //    {
            //        item.transform.localPosition = Vector3.zero;
            //        item.transform.localRotation = Quaternion.identity;
            //        item.gameObject.SetActive(true); // active
            //        isFound = true;
            //        break;
            //    }
            //}

            //if (!isFound)
            //{
            //    GameObject obj = Instantiate(monsterAPrefab, monsterParent);
            //    obj.transform.localPosition = Vector3.zero;
            //    obj.transform.localRotation = Quaternion.identity;
            //    monsterAs.Add(obj.GetComponent<MonsterA>());
            //}
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject obj = objectPoolManager.GetObjectByPrefab(monsterBPrefab, monsterParent, Vector3.zero, Quaternion.identity);
        }
    }
}
