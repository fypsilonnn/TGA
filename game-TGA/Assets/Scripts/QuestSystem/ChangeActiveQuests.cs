using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeActiveQuests : MonoBehaviour
{
    public Text activeQuestOne;
    public Text activeQuestTwo;
    public Text activeQuestThree;

    public void changingDescription(Text description) {
        description.text = "";
    }
}
