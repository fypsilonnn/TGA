using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] speaker;

    [TextArea]
    public string[] sentences; 

    public int[] speakingPosition;
}
