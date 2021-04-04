using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuWidget : MenuWidget
{
    public GameObject SaveSlotPrefab;
    public RectTransform SaveSlotHolder;

    [SerializeField] private bool debug;
    [SerializeField] private string SceneToLoad;
    [SerializeField] private InputField newGameInputField;
    private const string SaveFileKey = "FileSaveData";
    private GameDataList GameData;


    private void Start()
    {
        WipeChildren();
        if(debug)
        {
            SaveDebugData();
        }

        LoadGameData();
    }



    private void SaveDebugData()
    {
        GameDataList dataList = new GameDataList();
        dataList.SaveFileNames.AddRange(new List<string> {"Save1", "Save2", "Save3"});
        PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dataList));
    }

    private void LoadGameData()
    {
        if (!PlayerPrefs.HasKey(SaveFileKey))
        {
            Debug.Log("No Game Data Available");
            return;
        }

        string jsonString = PlayerPrefs.GetString(SaveFileKey);
        GameData = JsonUtility.FromJson<GameDataList>(jsonString);

        if (GameData.SaveFileNames.Count > 0)
        {
            foreach (string saveName in GameData.SaveFileNames)
            {
                SaveSlotWidget widget = Instantiate(SaveSlotPrefab,SaveSlotHolder).GetComponent<SaveSlotWidget>();
                widget.Init(this, saveName);
            }
        }
        else
        {
            return;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void CreateNewGame()
    {
        if (string.IsNullOrEmpty(newGameInputField.text)) return;
        GameManager.Instance.SetActiveSave(newGameInputField.text);
        LoadScene();
    }

    private void WipeChildren()
    {
        for(int i = 0; i < SaveSlotHolder.childCount; i++)
        {
            Destroy(SaveSlotHolder.GetChild(i).gameObject);
        }
    }

}


[SerializeField]
class GameDataList
{
    public List<string> SaveFileNames = new List<string>();

}

