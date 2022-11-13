using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    #region Player

    //stages are divided in stages and substages
    //e.g. stage[0] = mainstage -> SDG 14; stage[1] = substage -> over acidification or oil from wreck; stage[2] = part of substage -> the beach, planting the seaweed
    public int[] stage = new int[3];
    public List<int> indexKeys0;
    public List<int> indexKeys1;
    public List<int> indexKeys2;
    public List<string> stageNames;

    //this will be used to store the vector of the player position because Vector3 is not serializable
        //NOTE: ok, apparently vectors would be serializable but it is what it is
    public float[] playerPosition = new float[3];

    #endregion

    #region Quests

    //the current Quest
    public string currentQuest;

    //a complete list of all quests
    public List<string> questNames;

    //a list with all descriptions as a solution until I have something less ugly
    public List<string> descriptions;

    //saving and checking which quests are completed -> Dictionary
    public SerializableDictionary<string, bool> questProgress;

    //saving which quests are active
    public SerializableDictionary<string, string> questDescriptions;

    //saving which game objects are finishing triggers for which quests
    public SerializableDictionary<string, string> questTriggers;

    #endregion

    #region Minigames

    public int trashbagsCollected;

    #endregion
    //values defined in constructor will be the default values
    //this is used by the game if there is no data to load
    public GameData() {

        #region Player
 
        stage[0] = 1;
        stage[1] = 1;
        stage[2] = 1;

        playerPosition[0] = 260;    //x
        playerPosition[1] = 750;    //y
        playerPosition[2] = 0;      //z

        indexKeys0 = new List<int> {
            1,
            1
        };

        indexKeys1 = new List<int> {
            1,
            1
        };

        indexKeys2 = new List<int> {
            1,
            2
        };

        stageNames = new List<string> {
            "LevelOneBeach",
            "LevelOneKelp"
        };

        #endregion

        #region Quests

        currentQuest = "1-1_meetOliver";

        questNames = new List<string> {
            "1-1_meetOliver", 
            "1-1_cleanTheBeach", 
            "1-1_talkToOliverAgain"
        };

        descriptions = new List<string> {
            "Meet Oliver at the beach.",
            "Help Oliver to clean up the beach.",
            "Talk to Oliver again."
        };

        //<questName, hasFinished?>
        questProgress = new SerializableDictionary<string, bool>();
        foreach(string name in questNames) {
            questProgress.Add(name, false);
        }
        
        //TODO - denk dir was besseres aus
        //<questName, questDescription>
        questDescriptions = new SerializableDictionary<string, string>();
        for(int i = 0; i < questNames.Count; i++) {
            questDescriptions.Add(questNames[i], descriptions[i]);
        }

        questTriggers = new SerializableDictionary<string, string> {
            {questNames[0] , "Oliver"},
            {questNames[1], "MG_Trashbags"},
            {questNames[2], "temp2"}
        };

        #endregion

        #region Minigames

        trashbagsCollected = 0;

        #endregion

    }
}
