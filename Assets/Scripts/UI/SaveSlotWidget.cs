using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotWidget : MonoBehaviour
{
    private string SaveName;
    private GameManager Manager;
    private LoadMenuWidget LoadWidget;

    [SerializeField] private Text saveText;


    private void Awake()
    {
        Manager = GameManager.Instance;
    }

    public void Init(LoadMenuWidget parentWidget, string saveName)
    {
        LoadWidget = parentWidget;
        SaveName = saveName;
        saveText.text = saveName;
    }

    public void SelectSave()
    {
        Manager.SetActiveSave(SaveName);
        LoadWidget.LoadScene();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
