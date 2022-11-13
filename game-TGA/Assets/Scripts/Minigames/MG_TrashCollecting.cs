using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MG_TrashCollecting : MonoBehaviour, IDataPersistence
{
    #region vars

    private bool sendMGEnding;
    public int trashMinXCoord = 1500;
    public int trashMaxXCoord = 10000;
    public float trashYCoord = 400;
    System.Random rand = new System.Random();
    public GameObject[] trashbags = new GameObject[10];

    public GameObject starter;

    public int piecesCollected = 0;
    public TMP_Text display; 

    #endregion

    public void LoadData(GameData data) {
        piecesCollected = data.trashbagsCollected;
    }

    public void SaveData(GameData data) {
        data.trashbagsCollected = piecesCollected;
    }

    private void Start() {
        //TODO - change to take in already collected bags from previous saves -> guids
        foreach (GameObject bag in trashbags) {
            float x = (float)(rand.Next(trashMinXCoord, trashMaxXCoord));
            Vector3 trashPos = new Vector3();
            trashPos.Set(x, trashYCoord, 0f);
            bag.transform.position = trashPos;
        }
         display.text = "You have collected " + piecesCollected + " out of 10 trash pieces";
    }
    
    private void FixedUpdate() {
        if(piecesCollected == trashbags.Length && !sendMGEnding) {
            sendMGEnding = true;
            EndMG();
        }
        int inactiveBagsTemp = 0;
        foreach (GameObject bag in trashbags) {
            if (!bag.activeInHierarchy) {
                inactiveBagsTemp++;
            }
        }
        piecesCollected = inactiveBagsTemp;
        UpdateDisplay();
    }
    public void UpdateDisplay() {
        display.text = "You have collected " + piecesCollected + " out of 10 trash pieces";
    }

    //closing the minigame once all bags were collected
    public void EndMG() {
        //update quest
        FindObjectOfType<QuestHandler>().MarkQuestFinished(starter);

        //make the info template disappear
        display.gameObject.SetActive(false);

        //TODO - Oliver2 talkable
    }
}
