using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject dialogueBox;

    private Queue<string> sentences = new Queue<string>();

    private Queue<string> speakers = new Queue<string>();

    public void StartDialogue(Dialogue dialogue) {

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        foreach(string name in dialogue.speaker) {
            speakers.Enqueue(name);
        }

        DislplayNextSentence();
    }

    public void DislplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string nameToDisplay = speakers.Dequeue();
        nameText.text = nameToDisplay;

        string lineToSay = sentences.Dequeue();
        dialogueText.text = lineToSay;
    }

    public void EndDialogue() {
        //TODO - start next thing, e.g. minigame
        dialogueBox.SetActive(false);
    }
} 
