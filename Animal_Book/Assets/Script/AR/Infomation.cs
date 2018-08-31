using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Infomation : MonoBehaviour {
    public GameObject ARCamera;
    public GameObject InfoUI;
    public GameObject btnInfo;
    public GameObject btnQuit;
    int index = 0;
	// Use this for initialization
	void Start () {

	}
	public void ShowInfo()
    {
        InfoUI.SetActive(true);
        ARCamera.SetActive(false);
        btnInfo.SetActive(false);
    }
    public void ExitInfo()
    {
        ARCamera.SetActive(true);
        InfoUI.SetActive(false);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
