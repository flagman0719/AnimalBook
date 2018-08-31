using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FindAnimal : MonoBehaviour {
    public Text txtName;
    public GameObject objName;
    private DFTGames.Localization.Localize changelanguage;
    private int index;
    private int sceneIndex;
    private bool isFinished;
    public GameObject[] animal; // ga-0| ngua-1 | vit-2| lon-3
    public GameObject complete, effect;
    AudioSource source;
    //public AudioClip nen;
    public AudioClip clip2;
    // Use this for initialization
    void Start () {
        source = gameObject.GetComponent<AudioSource>();
        //source.clip = nen;
        //source.loop = true;
        //source.Play();
        changelanguage = objName.GetComponent<DFTGames.Localization.Localize>();
        isFinished = false;
    }

    // Update is called once per frame
    void Update () {
        foreach(GameObject animals in animal)
        {
            if (!animals.activeInHierarchy)
                index += 1;
        }
        if (index == animal.Length && !isFinished)
        {
            isFinished = true;
            source.PlayOneShot(clip2);
            int levelcount = PlayerPrefs.GetInt("levelCount");
            PlayerPrefs.SetInt("levelCount", levelcount + 1);
            complete.SetActive(true);
            effect.SetActive(true);
            StartCoroutine(ChangeNextScene());
        }

        index = 0;
	}
    IEnumerator ChangeNextScene()
    {
        yield return new WaitForSeconds(3f);
        sceneIndex = Application.loadedLevel + 1;
        SceneManager.LoadScene(sceneIndex);
    }
    public void ClickGa()
    {
        txtName.text = "Con gà";
        changelanguage.localizationKey = "chicken";
        StartCoroutine(DisableObject(0));
        //animal[0].SetActive(false);
    }
    public void ClickNgua()
    {
        //animal[1].SetActive(false);
        StartCoroutine(DisableObject(1));
        txtName.text = "Con ngựa";
        changelanguage.localizationKey = "horse";
    }
    public void ClickVit()
    {
        StartCoroutine(DisableObject(2));
        // animal[2].SetActive(false);
        txtName.text = "Con vịt";
        changelanguage.localizationKey = "duck";
    }
    public void ClickLon()
    {
        StartCoroutine(DisableObject(3));
        //animal[3].SetActive(false);
        txtName.text = "Con lợn";
        changelanguage.localizationKey = "pig";
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(2);
    }
    IEnumerator DisableObject(int index)
    {
        yield return new WaitForSeconds(1);
        animal[index].SetActive(false);
    }
}
