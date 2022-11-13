using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int[] stage = new int[3];

    public int[] getStage() {
        return stage;
    }
}
