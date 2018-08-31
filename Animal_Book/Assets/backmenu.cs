using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backmenu : MonoBehaviour {

    public void doback()
    {
        Application.LoadLevel("select");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(2);
    }
}
