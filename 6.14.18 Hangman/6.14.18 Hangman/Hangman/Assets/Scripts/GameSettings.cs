using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {

    static GameSettings settings;

    static string selectedWordList;
    public string SelectedWordList {

        get {

            return selectedWordList;

        }
        set {

            selectedWordList = value;

        }

    }

    void Awake () {

        if (settings == null)
        {

            DontDestroyOnLoad(gameObject);
            settings = this;

        }
        else if(settings != this)
        {

            Destroy(gameObject);

        }

    }

    private void Start()
    {

        SelectedWordList = WordList.DefaultList;

    }

    void Update ()
    {
 


	}

}

public static class WordList
{

    public static readonly string DefaultList = "Assets/Resources/DefaultList.txt";
    //private static readonly  string EasyList = "";
    //private static readonly  string MediumList = "";
    //private static readonly  string HardList = "";

}