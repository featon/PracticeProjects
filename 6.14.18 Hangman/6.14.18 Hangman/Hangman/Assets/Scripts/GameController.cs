using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    #region Declarations
    public GameObject UI;
    static GameObject[] character;
    GameObject Character;

    [SerializeField]
    Sprite[] CharacterAtlas;

    Vector3 originalScale;
    Vector3 currentScale;
    float originalXFactor;
    float originalYFactor;
    float xFactor;
    float yFactor;
    #endregion

    void Start() {

        Character = Resources.Load<GameObject>("Character");
        CharacterAtlas = Resources.LoadAll<Sprite>("Letters");

        originalScale = Character.GetComponent<RectTransform>().localScale;
        originalXFactor = Character.GetComponent<RectTransform>().sizeDelta.x;
        originalYFactor = Character.GetComponent<RectTransform>().sizeDelta.y;

        //Load the Selected Wordlist and Read a Random Word
        WordListController.LoadList();
        WordListController.ReadRandom();

        //Begin to Lay out the "Board"
        DrawChars();

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            Reroll();

        }

    }

    void DrawChars() {

        //Count the Chars in the ActiveWord
        int chars = WordListController.ActiveWord.Length;

        character = new GameObject[chars];

        xFactor = Character.GetComponent<RectTransform>().sizeDelta.x;
        yFactor = Character.GetComponent<RectTransform>().sizeDelta.y;

        if (chars * xFactor > Screen.width)
        {

            currentScale = Character.GetComponent<RectTransform>().localScale;
            Character.GetComponent<RectTransform>().localScale =
                new Vector3(currentScale.x * 3 / 4, currentScale.y * 3 / 4, currentScale.z * 3 / 4);

            xFactor = xFactor * 3 / 4;
            yFactor = yFactor * 3 / 4;
        }
        else if (chars * xFactor <= Screen.width) {

            Character.GetComponent<RectTransform>().localScale = originalScale;
            xFactor = originalXFactor;
            yFactor = originalYFactor;

        }

        for (int i = 0; i < chars; i++)
        {

            //Instantiate each Character Space at the proper location based on the Origin.
            character[i] = Instantiate(Character,
                new Vector3(((-chars * xFactor / 2)
                    + (xFactor * i))
                    + (xFactor / 2), -200, 0), Quaternion.identity);

            character[i].transform.SetParent(UI.transform, false);

            //Pass pass the Indices character as an arg to get the proper sprite index, set the Image's sprite to that.
            character[i].transform.Find("Image").GetComponent<Image>().sprite
               = CharacterAtlas[GetCharIndex(WordListController.ActiveWord[i].ToString().ToUpper())];
            character[i].transform.Find("Image").GetComponent<Image>().SetNativeSize();

        }

    }

    private void OnApplicationQuit()
    {
        //Reset all to original scale
        Character.GetComponent<RectTransform>().localScale = originalScale;
        xFactor = originalXFactor;
        yFactor = originalYFactor;

    }

    int GetCharIndex(string charIndex) {

        if (charIndex == "A") {

            return 0;

        }
        else if (charIndex == "B")
        {

            return 1;

        } else if (charIndex == "C"){

            return 2;

        }
        else if (charIndex == "D")
        {

            return 3;

        }
        else if (charIndex == "E"){

            return 4;

        }
        else if (charIndex == "F")
        {

            return 5;

        }
        else if (charIndex == "G")
        {

            return 6;

        }
        else if (charIndex == "H")
        {

            return 7;

        }
        else if (charIndex == "I")
        {

            return 8;

        }
        else if (charIndex == "J")
        {

            return 9;

        }
        else if (charIndex == "K")
        {

            return 10;

        }
        else if (charIndex == "L")
        {

            return 11;

        }
        else if (charIndex == "M")
        {

            return 12;

        }
        else if (charIndex == "N")
        {

            return 13;

        }
        else if (charIndex == "O")
        {

            return 14;

        }
        else if (charIndex == "P")
        {

            return 15;

        }
        else if (charIndex == "Q")
        {

            return 16;

        }
        else if (charIndex == "R")
        {

            return 17;

        }
        else if (charIndex == "S")
        {

            return 18;

        }
        else if (charIndex == "T")
        {

            return 19;

        }
        else if (charIndex == "U")
        {

            return 20;

        }
        else if (charIndex == "V")
        {

            return 21;

        }
        else if (charIndex == "W")
        {

            return 22;

        }
        else if (charIndex == "X")
        {

            return 23;

        }
        else if (charIndex == "Y")
        {

            return 24;

        }
        else if (charIndex == "Z")
        {

            return 25;

        }
        else
        {

            return 26;

        }

    }

    void Reroll() {

        int index = 0;

        foreach (GameObject characters in character) {

            Destroy(character[index]);
            index++;
        }

        WordListController.ReadRandom();
        DrawChars();

    }

    void OnGUI()
    {

        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            Guess(e.keyCode.ToString());
        }

    }

    void Guess(string letter) {

        Debug.Log(letter);

    }

}

public class WordListController {

    private static string activeWord;
    public static string ActiveWord {
        get
        {
            return activeWord;
        }
        set
        {

            activeWord = value;

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

    public static void ReadRandom()
    {

        //>>Randomly choose one word from the WordList
        ActiveWord = word[Random.Range(0, word.Count)];
        Debug.Log("This is the ActiveWord: " + ActiveWord);

    }

}