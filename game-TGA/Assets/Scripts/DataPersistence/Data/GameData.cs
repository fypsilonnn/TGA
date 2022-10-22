using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    //stages are divided in stages and substages
    //e.g. stage[0] = mainstage -> SDG 14; stage[1] = substage -> over acidification or oil from wreck
    public int[] stage = new int[2];

    //this will be used to store the vector of the player position because Vector3 is not serializable
        //NOTE: ok, apparently vectors would be serializable but it is what it is
    public float[] playerPosition = new float[3];

    //a complete list of all quests
    public List<string> questNames;

    //saving and checking which quests are completed -> Dictionary
    public SerializableDictionary<string, bool> questProgress;

    //saving which quests are active
    public SerializableDictionary<string, bool> activeQuests;

    //values defined in constructor will be the default values
    //this is used by the game if there is no data to load
    public GameData() {
        stage[0] = 1;
        stage[1] = 1;

        playerPosition[0] = 260;    //x
        playerPosition[1] = 750;    //y
        playerPosition[2] = 0;      //z

        questNames = new List<string> {
            "1-1_meetOliver", 
            "1-1_exampleQuest1", 
            "1-1_deineMudda"
        };

        questProgress = new SerializableDictionary<string, bool>();
        foreach(string name in questNames) {
            questProgress.Add(name, false);
        }
        
        activeQuests = new SerializableDictionary<string, bool>();
        foreach(string name in questNames) {
            activeQuests.Add(name, false);
        }
    }
}
