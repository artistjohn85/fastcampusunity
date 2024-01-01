using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Transform parentWindow;
    [SerializeField] private GameObject prefabUpgradeA;
    [SerializeField] private GameObject prefabUpgradeB;
    [SerializeField] private GameObject prefabShop;

    private WindowManager windowManager;
    
    void Start()
    {
        windowManager = FindAnyObjectByType<WindowManager>();
    }

    public void OnClick_UpgradeA()
    {
        windowManager.NewWindow(prefabUpgradeA, parentWindow);
    }

    public void OnClick_UpgradeB()
    {
        windowManager.NewWindow(prefabUpgradeB, parentWindow);
    }

    public void OnClick_Shop()
    {
        windowManager.NewWindow(prefabShop, parentWindow);
    }

}
