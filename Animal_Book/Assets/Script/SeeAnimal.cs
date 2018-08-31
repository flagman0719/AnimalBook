using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SeeAnimal : MonoBehaviour
{
    public GameObject[] animal;
    public Text txtName;
    public GameObject objName;
    private DFTGames.Localization.Localize changelanguage;
    private Animator anim;
    private int index = 0;
    private int sceneIndex;
    private bool isShowName;
    public GameObject complete, effect;
    private float time;
    AudioSource source;
    //public AudioClip nen;
    public AudioClip clip2;
    // Use this for initialization
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        //source.clip = nen;
        //source.loop = true;
        //source.Play();
        changelanguage = objName.GetComponent<DFTGames.Localization.Localize>();
        animal[0].SetActive(true);
        anim = animal[0].GetComponent<Animator>();
        anim.SetBool("SlideOut", true);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if ((Input.GetMouseButtonDown(0)  || Input.touchCount > 0) && time > 0.5)
        {
           // Debug.Log(time);
            time = 0;
            if(isShowName)
            {
                if(index < animal.Length-1)
                {
                    anim.SetBool("SlideOut", false);
                    animal[index].SetActive(false);
                    animal[++index].SetActive(true);
                    isShowName = false;
                    txtName.text = "";
                }
                else
                {
                    source.PlayOneShot(clip2);
                    animal[index].SetActive(false);
                    int levelcount = PlayerPrefs.GetInt("levelCount");
                    PlayerPrefs.SetInt("levelCount", levelcount + 1);
                    complete.SetActive(true);
                    effect.SetActive(true);
                    StartCoroutine(ChangeNextScene());
                }
            }
            else
            {
                //Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                //RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero); 
                //if (hit.collider.tag == "animal")
                //{
                    SetNameAnimal();
                    isShowName = true;
                //}
            }
        }
    }
    IEnumerator ChangeNextScene()
    {
        yield return new WaitForSeconds(3f);
        sceneIndex = Application.loadedLevel + 1;
        SceneManager.LoadScene(sceneIndex);
    }
    void SetNameAnimal()
    {
        switch(index)
        {
            case 0:
                txtName.text = "Bò sữa";
                changelanguage.localizationKey = "milker";
                break;
            case 1:
                txtName.text = "Chó";
                changelanguage.localizationKey = "dog";
                break;
            case 2:
                txtName.text = "Cừu";
                changelanguage.localizationKey = "sheep";
                break;
            case 3:
                txtName.text = "Lợn";
                changelanguage.localizationKey = "pig";
                break;
            case 4:
                txtName.text = "Lừa";
                changelanguage.localizationKey = "donkey";
                break;
            case 5:
                txtName.text = "Mèo";
                changelanguage.localizationKey = "cat";
                break;
            case 6:
                txtName.text = "Thỏ";
                changelanguage.localizationKey = "rabbit";
                break;
            case 7:
                txtName.text = "Trâu";
                changelanguage.localizationKey = "buffalo";
                break;
            default:
                txtName.text = "";
                break;
        }

    }
}
