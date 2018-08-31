using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleShadow : MonoBehaviour {
    private int levelIndex;
    public GameObject complete, effect;
    private bool isFinished;
    AudioSource source;
   // public AudioClip nen;
    public AudioClip clip2;
    // Use this for initialization
    void Start () {
        source = gameObject.GetComponent<AudioSource>();
        isFinished = false;
        //source.clip = nen;
        //source.loop = true;
        //source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("PiecesCount") == 5 && !isFinished)
        {
            source.PlayOneShot(clip2);
            isFinished = true;
            int levelcount = PlayerPrefs.GetInt("levelCount");
            PlayerPrefs.SetInt("levelCount", levelcount + 1);
            complete.SetActive(true);
            effect.SetActive(true);
            PlayerPrefs.SetInt("PiecesCount", 0); 
            StartCoroutine(ChangeNextScene());
        }
    }
    IEnumerator ChangeNextScene()
    {
        yield return new WaitForSeconds(3f);
        levelIndex = Application.loadedLevel + 1;
        SceneManager.LoadScene(levelIndex);
    }
}
