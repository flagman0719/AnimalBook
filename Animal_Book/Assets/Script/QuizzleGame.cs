using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuizzleGame : MonoBehaviour {
    private int sceneIndex;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    public void GotoNextScene()
    {
        int levelcount = PlayerPrefs.GetInt("levelCount");
        PlayerPrefs.SetInt("levelCount", levelcount + 1);
        sceneIndex = Application.loadedLevel + 1;
        SceneManager.LoadScene(sceneIndex);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(1);
    }
}
