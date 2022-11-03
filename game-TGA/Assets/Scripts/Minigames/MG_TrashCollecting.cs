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
            bag.transform.Translate(-bag.transform.position.x, -bag.transform.position.y, -bag.transform.position.z);
            float x = (float)(rand.Next(trashMinXCoord, trashMaxXCoord));
            bag.transform.Translate(x, trashYCoord, 0);
        }
        display.text = "You have collected " + piecesCollected + " out of 10 trash pieces";
    }
    
    private void FixedUpdate() {
        if(piecesCollected == 10) {
            //end minigame
        }
    }
    public void updateDisplay() {
        display.text = "You have collected " + piecesCollected + " out of 10 trash pieces";
    }

    //TODO - method for updating the collected number of bags
    //TODO - closing the minigame once all bags were collected
    //TODO - displaying the amount of bags collected
}
