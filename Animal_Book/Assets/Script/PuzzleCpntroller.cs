using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleCpntroller : MonoBehaviour {

    public GameObject soundbutton;
    public GameObject mutebutton;


    public void hidesoundbutton()
    {
        soundbutton.SetActive(false);
        Time.timeScale = 0f;

        mutebutton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void showsoundbutton()
    {
        soundbutton.SetActive(true);
        Time.timeScale = 0f;

        mutebutton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MuteButton()
    {
        AudioListener.volume = 0F;
    }

    public void SoundButton()
    {
        AudioListener.volume = 1F;
    }

    public void back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void home()
    {
        SceneManager.LoadScene("select");
    }
    public void lai()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
