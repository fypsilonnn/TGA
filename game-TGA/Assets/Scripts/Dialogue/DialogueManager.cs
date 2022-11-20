using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _dialogueText;

    [SerializeField] private GameObject _gameUI;

    [SerializeField] private GameObject _dialogueBox;

    private Queue<string> _sentences = new Queue<string>();

    private Queue<string> _speakers = new Queue<string>();

    public void StartDialogue(Dialogue dialogue) {

        _sentences.Clear();
        _speakers.Clear();

        _gameUI.SetActive(false);

        foreach(string sentence in dialogue.sentences) {
            _sentences.Enqueue(sentence);
        }

        foreach(string name in dialogue.speaker) {
            _speakers.Enqueue(name);
        }

        DislplayNextSentence();
    }

    public void DislplayNextSentence() {
        if (_sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string nameToDisplay = _speakers.Dequeue();
        _nameText.text = nameToDisplay;

        string lineToSay = _sentences.Dequeue();
        _dialogueText.text = lineToSay;
    }

    public void EndDialogue() {
        //TODO - start next thing, e.g. minigame
        _dialogueBox.SetActive(false);
        _gameUI.SetActive(true);
    }
} 
