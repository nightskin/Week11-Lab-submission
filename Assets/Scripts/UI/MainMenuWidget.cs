using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWidget : MenuWidget
{
    public void GotoOptions()
    {
        menuController.EnableMenu("Options");
    }

    public void GotoLoad()
    {
        menuController.EnableMenu("Load");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
