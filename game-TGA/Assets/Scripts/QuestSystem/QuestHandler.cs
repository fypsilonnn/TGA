using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestHandler : MonoBehaviour, IDataPersistence
{
    public GameObject[] trigger; 
    public TMP_Text activeQuestText;

    private string currentQuest;
    private List<string> questNames = new List<string>();
    
    private SerializableDictionary<string, bool> questProgress = new SerializableDictionary<string, bool>();
    private SerializableDictionary<string, string> questDescriptions = new SerializableDictionary<string, string>();
    private SerializableDictionary<string, string> questTriggers = new SerializableDictionary<string, string>();

    public void LoadData(GameData data) {
        this.currentQuest = data.currentQuest;
        this.questNames = data.questNames;
        this.questProgress = data.questProgress;
        this.questDescriptions = data.questDescriptions;
        this.questTriggers = data.questTriggers;
        //TODO - make a savefile for the descriptions and make the program read it from there instead of the dictionary (?)

        //set the current description
        activeQuestText.text = questDescriptions[currentQuest];
    }

    public void SaveData(GameData data) {
        data.currentQuest = this.currentQuest;
        data.questProgress = this.questProgress;
    }

    //create texts in the quests popup that display the active quest
    public void MarkQuestFinished(GameObject startingObject) {
        if(this.questProgress.ContainsKey(currentQuest)) {
            this.questProgress[currentQuest] = true;
            //int currentTrigger = questNames.IndexOf(currentQuest);

            string descriptionToChange = questDescriptions[currentQuest];

            //check if there are more quests left after the one just finished, else say that there are no more quests
            if(questNames.IndexOf(currentQuest) == questNames.Count - 1) {
                activeQuestText.text = "There are no more quests to be done, you finished what's currently in the game";
            } 
            
            //check if you activated the right trigger, if the update description and completion
            else if((descriptionToChange.Equals(activeQuestText.text) || activeQuestText.text.Equals("")) && questNames.IndexOf(currentQuest) < questNames.Count - 1 && questTriggers[currentQuest].Equals(startingObject.name)) {
                activeQuestText.text = questDescriptions[questNames[questNames.IndexOf(currentQuest) + 1]];
                currentQuest = questNames[questNames.IndexOf(currentQuest) + 1];
            } 
            
            //do nothing if player just talked to the wrong person
            else if(questTriggers[currentQuest].Equals(trigger[questNames.IndexOf(currentQuest)].name)) {
                return;
            } 
            
            //error logging
            else {
                Debug.LogError("Something went wrong while trying to update the quest description.");
            } 
        } else {
            Debug.LogError("Something went wrong while getting the current quest.");
        }
    }

    
}

