using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Sprite btnimage;
    [SerializeField]
    private GameObject complete;
    public GameObject effect;
    public Sprite[] puzzles;
    private int index;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    private int sceneIndex;
    public List<Button> btns = new List<Button>();
    private int numberbtn;
    private bool firstGuess, secondGuess;
    private int countGuesses, countCorrectGuesses, gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;
   // public AudioClip nen;
    public AudioClip clip1;
    public AudioClip clip2;
    AudioSource source;
    public AudioClip[] AudioArray;
	// Use this for initialization
    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        puzzles = Resources.LoadAll<Sprite> ("texture/card-Recovered");
        //source.clip = nen;
        //source.loop = true;
        //source.Play();

    }
	void Start () {
        GetButtons();
        AddListener();
        AddPuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }
    void GetButtons()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < obj.Length; i++)
        {
            numberbtn = i;
            btns.Add(obj[i].GetComponent<Button>());
            btns[i].image.sprite = btnimage;
        }
    }
    void AddPuzzles()
    {
        //int looper = btns.Count;
        //int RandomIndex = Random.Range(0, 6);
        //index = RandomIndex;
        //int count = 0;
        //for (int i = 0; i < looper; i++)
        //{
        //    if (count == looper / 2)
        //    {
        //        index = RandomIndex;
        //    }
        gamePuzzles.Add(puzzles[0]);
        gamePuzzles.Add(puzzles[1]);
        gamePuzzles.Add(puzzles[5]);
        gamePuzzles.Add(puzzles[7]);
        gamePuzzles.Add(puzzles[0]);
        gamePuzzles.Add(puzzles[1]);
        gamePuzzles.Add(puzzles[5]);
        gamePuzzles.Add(puzzles[7]);
        //    index ++;
        //    count++;
        //}
    }
    void AddListener()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
            if (firstGuessPuzzle == "card-Recovered_1") source.PlayOneShot(AudioArray[0]);
            else if (firstGuessPuzzle == "card-Recovered_2") source.PlayOneShot(AudioArray[1]);
            else if (firstGuessPuzzle == "card-Recovered_3") source.PlayOneShot(AudioArray[2]);
            else if (firstGuessPuzzle == "card-Recovered_4") source.PlayOneShot(AudioArray[3]);
            else if (firstGuessPuzzle == "card-Recovered_5") source.PlayOneShot(AudioArray[4]);
            else if (firstGuessPuzzle == "card-Recovered_6") source.PlayOneShot(AudioArray[5]);
            else if (firstGuessPuzzle == "card-Recovered_7") source.PlayOneShot(AudioArray[6]);
            else if (firstGuessPuzzle == "card-Recovered_8") source.PlayOneShot(AudioArray[7]);
            else if (firstGuessPuzzle == "card-Recovered_9") source.PlayOneShot(AudioArray[8]);
            else if (firstGuessPuzzle == "card-Recovered_10") source.PlayOneShot(AudioArray[9]);
         
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            if (secondGuessIndex == firstGuessIndex)
            {
                secondGuess = false;
                return;
            }
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            if (secondGuessPuzzle == "card-Recovered_1") source.PlayOneShot(AudioArray[0]);
            else if (secondGuessPuzzle == "card-Recovered_2") source.PlayOneShot(AudioArray[1]);
            else if (secondGuessPuzzle == "card-Recovered_3") source.PlayOneShot(AudioArray[2]);
            else if (secondGuessPuzzle == "card-Recovered_4") source.PlayOneShot(AudioArray[3]);
            else if (secondGuessPuzzle == "card-Recovered_5") source.PlayOneShot(AudioArray[4]);
            else if (secondGuessPuzzle == "card-Recovered_6") source.PlayOneShot(AudioArray[5]);
            else if (secondGuessPuzzle == "card-Recovered_7") source.PlayOneShot(AudioArray[6]);
            else if (secondGuessPuzzle == "card-Recovered_8") source.PlayOneShot(AudioArray[7]);
            else if (secondGuessPuzzle == "card-Recovered_9") source.PlayOneShot(AudioArray[8]);
            else if (secondGuessPuzzle == "card-Recovered_10") source.PlayOneShot(AudioArray[9]);

            //if (countGuesses >= 10)
            //{
            //    source.PlayOneShot(AudioArray[11]);
            //    fail.SetActive(true);
            //   // SceneManager.LoadScene("viduhome");
            //}
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            // Play sound
            source.PlayOneShot(clip1);
            //yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
           // btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
           // btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfTheGameIsFinished();
        }
        else
        {
            source.PlayOneShot(AudioArray[10]);
            btns[firstGuessIndex].image.sprite = btnimage;
            btns[secondGuessIndex].image.sprite = btnimage;

        }
       // yield return new WaitForSeconds(.5f);
        firstGuess = secondGuess = false;
    }
    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses && countGuesses < 10)
        {
            int levelcount = PlayerPrefs.GetInt("levelCount");
            PlayerPrefs.SetInt("levelCount", levelcount + 1);
            source.PlayOneShot(clip2);
            complete.SetActive(true);
            effect.SetActive(true);
            StartCoroutine(GoNextScene());
        }
    }
    IEnumerator GoNextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int RandomIndex = Random.Range(0, list.Count);
            list[i] = list[RandomIndex];
            list[RandomIndex] = temp;
        }
    }
}
