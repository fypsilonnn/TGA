using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenu : MonoBehaviour, IDataPersistence
{
    private int[] stageToLoad = new int[3];

    private Dictionary<int[], string> stageIndexes = new SerializableDictionary<int[], string>();

    public void LoadData(GameData data) {
        stageToLoad = data.stage;

        foreach(KeyValuePair<int[], string> kvp in this.stageIndexes) {
            Debug.Log("Key: " + kvp.Key);
            Debug.Log("Value: " + kvp.Value);
        }

        for(int i = 0; i < data.indexKeys0.Count; i++) {
            int[] index = new int[3];
            index[0] = data.indexKeys0[i];
            index[1] = data.indexKeys1[i];
            index[2] = data.indexKeys2[i];
            stageIndexes.Add(index, data.stageNames[i]);
        }
    }

    public void SaveData(GameData data) {

    }

    public void PlayLevelOne() {
        //TODO Load the correct stage
        SceneManager.LoadScene(stageIndexes[stageToLoad]);
    }
}
