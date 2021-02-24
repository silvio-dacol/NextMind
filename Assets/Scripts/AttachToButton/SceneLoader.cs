using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//Script to be attached to the button: be sure the name of button and name of the scene coincide

//If you are trying to attach this to the StartExperiment and ExitExperiment buttons, StartExperiment shall be in the General Scene

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        //I get and store all the loaded scenes in an array
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
    }

    public void StartExperimentButton()
    {
        //I get and store all the loaded scenes in an array
        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }

        //I unload the loaded scenes except the General one (which contains the essential things)
        for (int i = 0; i < countLoaded; i++)
        {
            if (loadedScenes[i].name != "General")
            {
                SceneManager.UnloadSceneAsync(loadedScenes[i].name);
            }
        }

        //I load the scene relative to that specific task button
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        //I hide the StartExperiment button
        GameObject.Find("StartExperiment").transform.localScale = new Vector3(0, 0, 0);
    }

    public void ExitExperimentButton()
    {
        //I get and store all the loaded scenes in an array
        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }

        //I unload the loaded scenes except the General one (which contains the essential things)
        for (int i = 0; i < countLoaded; i++)
        {
            if (loadedScenes[i].name != "General")
            {
                SceneManager.UnloadSceneAsync(loadedScenes[i].name);
            }
        }

        //I load the StartExperiment button again
        GameObject.Find("StartExperiment").transform.localScale = new Vector3(1, 1, 1);
    }
}
