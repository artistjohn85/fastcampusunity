using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnitInfo
{
    public readonly int id;
    public readonly string name;

    public ItemUnitInfo(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    private List<ItemUnit> itemUnits = new List<ItemUnit>(); // 생성한 정보를 담습니다.

    private List<ItemUnitInfo> itemUnitInfos = new List<ItemUnitInfo>(); // 정보

    void Start()
    {
        itemUnitInfos.Add(new ItemUnitInfo(1, "노멀 버드"));
        itemUnitInfos.Add(new ItemUnitInfo(2, "레어 버드"));
        itemUnitInfos.Add(new ItemUnitInfo(3, "유니크 버드"));

        foreach (var unit in itemUnitInfos)
        {
            GameObject obj = Instantiate(itemPrefab, transform);
            ItemUnit itemUnit = obj.GetComponent<ItemUnit>();
            itemUnit.SetInit(unit, RemoveItem);
            itemUnits.Add(itemUnit);
        }
    }

    public void RemoveItem(ItemUnit itemUnit)
    {
        Destroy(itemUnit.gameObject);
        itemUnits.Remove(itemUnit);
    }
}
