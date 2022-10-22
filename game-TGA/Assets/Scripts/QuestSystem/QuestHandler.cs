using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour, IDataPersistence
{
    public Text activeQuest;

    public List<string> questNames = new List<string>();
    public SerializableDictionary<string, bool> questProgress = new SerializableDictionary<string, bool>();
    public SerializableDictionary<string, bool> activeQuests = new SerializableDictionary<string, bool>();
    public SerializableDictionary<string, string> questDescriptions = new SerializableDictionary<string, string>();


    void Start() {
        
    }

    public void LoadData(GameData data) {
        this.questProgress = data.questProgress;
        this.activeQuests = data.activeQuests;
        //TODO - update Load and Save to questDescriptions
        //TODO - make a savefile for the descriptions and make the program read it from there instead of the dictionary (?)
    }

    public void SaveData(GameData data) {
        data.questProgress = this.questProgress;
        data.activeQuests = this.activeQuests;
    }

    public void markQuestFinished(string finishedQuest) {
        if(this.questProgress.ContainsKey(finishedQuest) && this.activeQuests.ContainsKey(finishedQuest)) {
            this.questProgress[finishedQuest] = true;
            this.activeQuests[finishedQuest] = false;

            string descriptionToChange = questDescriptions[finishedQuest];
            //check if there are more quests left after the one just finished, else say that there are no more quests 
            if(descriptionToChange.Equals(activeQuest.text) && questNames.IndexOf(finishedQuest) < questNames.Count) {
                activeQuest.text = questDescriptions[questNames[questNames.IndexOf(finishedQuest) + 1]];       //questNames.IndexOf(finishedQuest) + 1
            } else if(questNames.IndexOf(finishedQuest) == questNames.Count) {
                activeQuest.text = "There are no more quests to be done, you finished whats currently in the game";
            } else {
                Debug.LogError("Something went wrong while trying to update the quest description.");
            }
        }
    }
    //TODO - create texts in the quests popup that display the active quests
}
