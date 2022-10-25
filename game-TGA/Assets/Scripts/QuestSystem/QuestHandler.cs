using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestHandler : MonoBehaviour, IDataPersistence
{
    public GameObject[] trigger = new GameObject[3]; //TODO - determine sizes

    public TMP_Text activeQuest;

    private string currentQuest;
    public List<string> questNames = new List<string>();
    //public List<GameObject> trigger = new List<GameObject>();
    public SerializableDictionary<string, bool> questProgress = new SerializableDictionary<string, bool>();
    public SerializableDictionary<string, string> questDescriptions = new SerializableDictionary<string, string>();
    public SerializableDictionary<string, string> questTriggers = new SerializableDictionary<string, string>();

    public void LoadData(GameData data) {
        this.currentQuest = data.currentQuest;
        this.questNames = data.questNames;
        this.questProgress = data.questProgress;
        this.questDescriptions = data.questDescriptions;
        this.questTriggers = data.questTriggers;
        //TODO - make a savefile for the descriptions and make the program read it from there instead of the dictionary (?)

        //set the current description
        activeQuest.text = questDescriptions[currentQuest];
    }

    public void SaveData(GameData data) {
        data.currentQuest = this.currentQuest;
        data.questProgress = this.questProgress;
    }

    //create texts in the quests popup that display the active quest
    public void markQuestFinished() {
        if(this.questProgress.ContainsKey(currentQuest)) {
            this.questProgress[currentQuest] = true;
            //int currentTrigger = questNames.IndexOf(currentQuest);

            string descriptionToChange = questDescriptions[currentQuest];

            //check if there are more quests left after the one just finished, else say that there are no more quests
            if(questNames.IndexOf(currentQuest) == questNames.Count - 1) {
                activeQuest.text = "There are no more quests to be done, you finished what's currently in the game";
            } else if(descriptionToChange.Equals(activeQuest.text) && questNames.IndexOf(currentQuest) < questNames.Count - 1 && questTriggers[currentQuest].Equals(trigger[questNames.IndexOf(currentQuest)].name)) {
                activeQuest.text = questDescriptions[questNames[questNames.IndexOf(currentQuest) + 1]];
                currentQuest = questNames[questNames.IndexOf(currentQuest) + 1];
            } else if(questTriggers[currentQuest].Equals(trigger[questNames.IndexOf(currentQuest)].name)) {

            } else {
                Debug.LogError("Something went wrong while trying to update the quest description.");
            } 
        } else {
            Debug.LogError("Something was wrong while getting the current quest.");
        }
    }

    
}

