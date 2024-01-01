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
            = new PopupMessageInfo(type: POPUP_MESSAGE_TYPE.TWO_BUTTON, title: "업데이트 안내", contents: "업데이트 하시겠습니까?");
        popupMessage.OpenMessage(popupMessageInfo, CancleUpdate, GoUpdate);
    }

    private void MaintenancePopup()
    {
        GameObject gameObject = Instantiate(prefabPopupMessage, parentPopupMessage);
        PopupMessage popupMessage = gameObject.GetComponent<PopupMessage>();
        PopupMessageInfo popupMessageInfo
            = new PopupMessageInfo(type: POPUP_MESSAGE_TYPE.ONE_BUTTON, title: "점검 안내", contents: "점검 중 입니다.");
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
