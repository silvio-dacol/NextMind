using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSelectionCorrectness : MonoBehaviour
{
    public int selectionCount;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
