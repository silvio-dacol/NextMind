using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //I create a Method which opens the scene with inside all the basic things
    public void ButtonMoveScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
}
