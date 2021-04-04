using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MenuController : MonoBehaviour
{
    [SerializeField] string StartMenu = "Main Menu";
    [SerializeField] string rootMenu = "Main Menu";


    private MenuWidget ActiveMenu;
    private Dictionary<string, MenuWidget> Menus = new Dictionary<string, MenuWidget>();

    public void AddMenu(string menuName, MenuWidget menuWidget)
    {
        if(string.IsNullOrEmpty(menuName))
        {
            return;
        }
        if(Menus.ContainsKey(menuName))
        {
            Debug.LogError("Menu Already Exists");
            return;
        }
        if(menuWidget == null)
        {
            return;
        }

        Menus.Add(menuName,menuWidget);
    }
    
    public void EnableMenu(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
        {
            return;
        }
        if (Menus.ContainsKey(menuName))
        {
            DisableActiveMenu();

            ActiveMenu = Menus[menuName];
            ActiveMenu.EnableWidget();
        }
        else
        {
            Debug.LogError("Menu Is Not Available");
        }

    }

    public void DisableMenu(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
        {
            return;
        }
        if (Menus.ContainsKey(menuName))
        {
            DisableActiveMenu();

            ActiveMenu = Menus[menuName];
            Menus[menuName].DisableWidget();
        }
        else
        {
            Debug.LogError("Menu Is Not Available");
        }
    }
    
    public void ReturnToRoot()
    {
        EnableMenu(rootMenu);
    }

    private void DisableActiveMenu()
    {
        if (ActiveMenu)
        {
            ActiveMenu.DisableWidget();
        }
    }

    private void DisableAllMenus()
    {
        foreach(MenuWidget menu in Menus.Values)
        {
            menu.DisableWidget();
        }

    }

    void Start()
    {
        DisableAllMenus();
        EnableMenu(StartMenu);
    }

    
}


