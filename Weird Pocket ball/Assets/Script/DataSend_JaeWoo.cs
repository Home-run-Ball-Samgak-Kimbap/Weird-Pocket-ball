using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_JaeWoo : MonoBehaviour
{
    public static Data_JaeWoo instance;

    public string ball;
    public string table;
    public string cue;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
