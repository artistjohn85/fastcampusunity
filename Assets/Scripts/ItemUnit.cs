using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUnit : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private ItemUnitInfo itemUnitInfo;
    private Action<ItemUnit> removeAction;

    public void SetInit(ItemUnitInfo itemUnitInfo, Action<ItemUnit> removeAction)
    {
        this.itemUnitInfo = itemUnitInfo;
        this.removeAction = removeAction;
        text.text = itemUnitInfo.name;
    }

    public void OnClick_remove()
    {
        Debug.Log($"Click, Item Id: {itemUnitInfo.id}, Item name: {itemUnitInfo.name}");
        //transform.parent.GetComponent<ItemController>().RemoveItem(this); // ���� ����� �ƴ�
        //itemController.RemoveItem(this); // ���� ����� �ƴ�
        //FindAnyObjectByType<ItemController>();
        this.removeAction?.Invoke(this);
    }
}
