using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenu : MonoBehaviour, IDataPersistence
{
    private int[] stageToLoad = new int[3];
    private SerializableDictionary<string, string> stageIndexes = new SerializableDictionary<string, string>();

    public void LoadData(GameData data) {
        this.stageToLoad = data.stage;

        Debug.Log("load1: " + stageToLoad[0] + "data: " + data.stage[0]);
        Debug.Log("load2: " + stageToLoad[1] + "data: " + data.stage[1]);
        Debug.Log("load3: " + stageToLoad[2] + "data: " + data.stage[2]);

        this.stageIndexes = data.stageIndexes;
    }

    public void SaveData(GameData data) {

    }

    public void PlayLevelOne() {

        //TODO Load the correct stage

        SceneManager.LoadScene(stageIndexes[stageToLoad[0].ToString() + "-" + stageToLoad[1].ToString() + "-" + stageToLoad[2].ToString()]);
    }
}
