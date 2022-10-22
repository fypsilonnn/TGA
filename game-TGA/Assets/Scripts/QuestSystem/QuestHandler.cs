using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour, IDataPersistence
{
    public Text activeQuestOne;
    public Text activeQuestTwo;
    public Text activeQuestThree;

    public SerializableDictionary<string, bool> questProgress = new SerializableDictionary<string, bool>();
    public SerializableDictionary<string, bool> activeQuests = new SerializableDictionary<string, bool>();



    void Start() {
        
    }

    public void LoadData(GameData data) {
        this.questProgress = data.questProgress;
        this.activeQuests = data.activeQuests;
    }

    public void SaveData(GameData data) {
        data.questProgress = this.questProgress;
        data.activeQuests = this.activeQuests;
    }

    public void markQuestFinished(string questName) {
        if(this.questProgress.ContainsKey(questName) && this.activeQuests.ContainsKey(questName)) {
            this.questProgress[questName] = true;
            this.activeQuests[questName] = false;

            string questDescription; //= get description of changed quest 

            /*switch(questDescription) {
                case activeDescriptionOne :
                    break;
                case:
                    break;
                case "2" :
                    break;
                default: 
                    Debug.LogError("Something went wrong while trying to Update active quest descriptions.");
                    break; */

            if(questDescription.Equals(activeQuestOne.text)) {
                //jeweiliges feld updaten
            } else if (questDescription.Equals(activeQuestTwo.text)) {

            } else if (questDescription.Equals(activeQuestThree.text)) {
                
            }
        }
    }
    //TODO - create texts in the quests popup that display the active quests
}
