using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MG_TrashCollecting : MonoBehaviour
{
    public int trashMinXCoord = 1500;
    public int trashMaxXCoord = 10000;
    public float trashYCoord = 400;
    System.Random rand = new System.Random();
    public GameObject[] trashbags = new GameObject[10];

    public int piecesCollected = 0;
    public TMP_Text display; 
    private void Start() {
        foreach (GameObject bag in trashbags) {
            float x = (float)(rand.Next(trashMinXCoord, trashMaxXCoord));
            Vector3 trashPos = new Vector3();
            trashPos.Set(x, trashYCoord, 0f);
            bag.transform.position = trashPos;
        }
         display.text = "You have collected " + piecesCollected + " out of 10 trash pieces";
    }
    
    private void FixedUpdate() {
        if(piecesCollected == 10) {
            //TODO - end minigame
            
        }
    }
    public void UpdateDisplay() {
        display.text = "You have collected " + piecesCollected + " out of 10 trash pieces";
    }

    //TODO - closing the minigame once all bags were collected
}
