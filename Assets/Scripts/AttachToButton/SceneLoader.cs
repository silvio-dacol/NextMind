using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//Script to be attached to the button: be sure the name of button and name of the scene coincide

public class SceneLoader : MonoBehaviour
{
    //public bool startOverallSceneTime;
    //public bool startTaskExercise;

    public void LoadScene()
    {
        //I get and store all the scenes in an array
        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for(int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }

        //I unload the loaded scenes except the General one (which contains the essential things)
        for(int i = 0; i < countLoaded; i++)
        {
            if(loadedScenes[i].name != "General")
            {
                SceneManager.UnloadSceneAsync(loadedScenes[i].name);
            }
        }

        //I load the scene relative to that specific task button
        SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);

        //For the future, see how to implement the passing of time
        //startOverallSceneTime = true;
        //startTaskExercise = true;
    }
}
