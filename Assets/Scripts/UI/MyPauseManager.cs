using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyPauseManager : MonoBehaviour
{
    public static MyPauseManager instance = null;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        UnPauseGame();
    }

    public void PauseGame()
    {
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
        foreach(IPausable p in pausables)
        {
            p.PauseGame();
        }

        Time.timeScale = 0;
        AppEvents.Invoke_OnMouseCursorEnable(true);
    }

    public void UnPauseGame()
    {
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
        foreach (IPausable p in pausables)
        {
            p.UnPauseGame();
        }

        Time.timeScale = 1;
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }

    private void OnDestroy()
    {
        UnPauseGame();
    }

}



interface IPausable
{
    void PauseGame();
    void UnPauseGame();
}