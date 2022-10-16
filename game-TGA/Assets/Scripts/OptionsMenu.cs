using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void PlayLevelOne() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //TEMP!!!
    public void ToHomescreen() {
        SceneManager.LoadScene(0);
    }
}
