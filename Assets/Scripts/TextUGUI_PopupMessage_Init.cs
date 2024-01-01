using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUGUI_PopupMessage_Init : MonoBehaviour
{
    [SerializeField] GameObject prefabPopupMessage;
    [SerializeField] Transform parentPopupMessage;   
    
    void Start()
    {
        UpdatePopup();
    }

    private void UpdatePopup()
    {
        GameObject gameObject = Instantiate(prefabPopupMessage, parentPopupMessage);
        PopupMessage popupMessage = gameObject.GetComponent<PopupMessage>();
        PopupMessageInfo popupMessageInfo
            = new PopupMessageInfo(type: POPUP_MESSAGE_TYPE.TWO_BUTTON, title: "������Ʈ �ȳ�", contents: "������Ʈ �Ͻðڽ��ϱ�?");
        popupMessage.OpenMessage(popupMessageInfo, CancleUpdate, GoUpdate);
    }

    private void MaintenancePopup()
    {
        GameObject gameObject = Instantiate(prefabPopupMessage, parentPopupMessage);
        PopupMessage popupMessage = gameObject.GetComponent<PopupMessage>();
        PopupMessageInfo popupMessageInfo
            = new PopupMessageInfo(type: POPUP_MESSAGE_TYPE.ONE_BUTTON, title: "���� �ȳ�", contents: "���� �� �Դϴ�.");
        popupMessage.OpenMessage(popupMessageInfo, null, GoMaintenance);
    }

    private void GoUpdate()
    {
        Debug.Log("Go Update");
    }

    private void CancleUpdate()
    {
        Debug.Log("Cancle Update");
        MaintenancePopup();
    }

    private void GoMaintenance()
    {
        Debug.Log("Go Update");
    }
}
