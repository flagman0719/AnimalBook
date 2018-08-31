using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectLevelControl : MonoBehaviour {
    public GameObject[] lockLevels;
    public GameObject[] level;
	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefs.GetInt("levelCount"));
        for (int i = 0; i < level.Length; i++)
        {
            int index = PlayerPrefs.GetInt("levelCount");
            if (i > index)
            {
                lockLevels[i].SetActive(true);
                Button btnLevel = level[i].GetComponent<Button>();
                btnLevel.interactable = false;
                Image levelImages = level[i].GetComponent<Image>();
                levelImages.color = new Color(250, 203, 104, 150);
            }
        }
    }
}
	
