using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuWidget : MonoBehaviour
{
    [SerializeField] private string menuName;
    protected MenuController menuController;
    private void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        if (menuController)
        {
            menuController.AddMenu(menuName, this);
        }
        else
        {
            Debug.LogError("Menu Controller Not Found");
        }
    }

    public void EnableWidget()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToRoot()
    {
        if(menuController)
        {
            menuController.ReturnToRoot();    
        }
    }

    public void DisableWidget()
    {
        gameObject.SetActive(false);
    }
}
