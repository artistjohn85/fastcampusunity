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
    private List<ItemUnit> itemUnits = new List<ItemUnit>(); // ������ ������ ����ϴ�.

    private List<ItemUnitInfo> itemUnitInfos = new List<ItemUnitInfo>(); // ����

    void Start()
    {
        itemUnitInfos.Add(new ItemUnitInfo(1, "��� ����"));
        itemUnitInfos.Add(new ItemUnitInfo(2, "���� ����"));
        itemUnitInfos.Add(new ItemUnitInfo(3, "����ũ ����"));

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
