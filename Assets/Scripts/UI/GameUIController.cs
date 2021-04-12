using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    
    [SerializeField] private GameHUDWidget GameCanvas;
    [SerializeField] private GameHUDWidget pauseCanvas;

    private GameHUDWidget activeWidget;

    private void Start()
    {
        DisableAllMenus();
        EnableGameMenu();
    }

    public void EnablePauseMenu()
    {
        if (activeWidget) activeWidget.DisableWidget();
        activeWidget = pauseCanvas;
        activeWidget.EnableWidget();
    }

    public void EnableGameMenu()
    {
        if (activeWidget) activeWidget.DisableWidget();
        activeWidget = GameCanvas;
        activeWidget.EnableWidget();
    }

    public void DisableAllMenus()
    {
        GameCanvas.DisableWidget();
        pauseCanvas.DisableWidget();
    }

}