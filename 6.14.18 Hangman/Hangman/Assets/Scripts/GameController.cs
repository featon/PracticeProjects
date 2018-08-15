using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour {

	void Start () {

        WordListController.LoadList();
        WordListController.ReadRandom();

	}
	
	void Update () {
		


	}

}

public class WordListController {

    private string activeWord;
    public string ActiveWord {
        get
        {
            return this.activeWord;
        }
        set
        {

            this.activeWord = value;

        }
    }

    static List<string> word = new List<string>();

    public static void LoadList() {

        //Loads the word list into a StreamReader
        StreamReader sr = new StreamReader(WordList.DefaultList);

        //Initiallize a counter index
        string tempWord = "";

        //Read each line and save it to the word List.
        while ((tempWord = sr.ReadLine()) != null)
        {

            word.Add(tempWord);

        }

    }

    public static void ReadRandom() {

        //Randomly choose one word from
        Debug.Log(word[Random.Range(0, word.Count)]);

    }
}