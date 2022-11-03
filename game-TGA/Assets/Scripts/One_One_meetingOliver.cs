using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class One_One_meetingOliver : MonoBehaviour
{
    
    public List<string> dialogueLines = new List<string> {
        //TODO - add Dialogue lines
    };
    public TMP_Text dialogueText;
    public GameObject player;
    public Vector3 dialogueStandingPos = new Vector3(0, 0, 0);

    public void changeLines() {
        if(dialogueLines.IndexOf(dialogueText.text).Equals(dialogueLines.Count - 1)) {
            //TODO - start MG_TrashCollecting
            SceneManager.LoadScene("MG_CollectingTrash");

        } else {
            //change Text to next thing said
            int i = dialogueLines.IndexOf(dialogueText.text);
            dialogueText.text = dialogueLines[i + 1];
        }
    }

    public void startConversation() {
        player.transform.position = dialogueStandingPos; 
    }
}
