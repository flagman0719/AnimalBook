using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DFTGames.Localization;
public class MenuManager : MonoBehaviour 
{
    //AudioSource source;
    //public AudioClip nen;
    [SerializeField]
	private string m_animationPropertyName;

	[SerializeField]
	private GameObject m_initialScreen;

	[SerializeField]
	private List<GameObject> m_navigationHistory;
    public GameObject background;
    public GameObject logo;
    public GameObject loading;
    public GameObject entertain;
    public Image imageComp;
    public Text text;
    public Text textNormal;
    AsyncOperation async; 
	public void GoBack()
	{
		if (m_navigationHistory.Count > 1)
		{
			int index = m_navigationHistory.Count - 1;
			Animate(m_navigationHistory[index - 1], true);

			GameObject target = m_navigationHistory[index];
			m_navigationHistory.RemoveAt(index);
			Animate(target, false);
		}
	}
    public void SetEnglish()
    {
        PlayerPrefs.SetInt("language", 1);
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
    }
    public void SetVietnamese()
    {
        PlayerPrefs.SetInt("language", 0);
        Localize.SetCurrentLanguage(SystemLanguage.Vietnamese);
        LocalizeImage.SetCurrentLanguage();
    }
    public void GoToMenu(GameObject target)
	{
		if (target == null)
		{
			return;
		}

		if (m_navigationHistory.Count > 0)
		{
			Animate(m_navigationHistory[m_navigationHistory.Count - 1], false);
		}

		m_navigationHistory.Add(target);
        if (entertain.activeInHierarchy)
        {
            Debug.Log("active");
            entertain.SetActive(false);
        }

        Animate(target, true);
    }

	private void Animate(GameObject target, bool direction)
	{
		if (target == null)
		{
			return;
		}

		target.SetActive(true);

		Canvas canvasComponent = target.GetComponent<Canvas>();
		if (canvasComponent != null)
		{
			canvasComponent.overrideSorting = true;
			canvasComponent.sortingOrder = m_navigationHistory.Count;
		}

		Animator animatorComponent = target.GetComponent<Animator>();
		if (animatorComponent != null)
		{
			animatorComponent.SetBool(m_animationPropertyName, direction);
		}
	}
    public void ShowViewBook()
    {
        StartCoroutine(SceneAnimal());
        //SceneManager.LoadScene("Animal");
    }
    public void _Quit()
    {
        Application.Quit();
    }
    public void LoadScene(int index)
    {
        StartCoroutine(LoadAsync(index));
    }
	private void Awake()
	{
        //source = gameObject.GetComponent<AudioSource>();
        //source.clip = nen;
        //source.loop = true;
        //source.Play();
        m_navigationHistory = new List<GameObject>{m_initialScreen};
        imageComp.fillAmount = 0.0f;
        background.SetActive(false);
        logo.SetActive(false);
        loading.SetActive(false);
        PlayerPrefs.SetInt("language", 0);
        if(!PlayerPrefs.HasKey("language"))
        {
            Localize.SetCurrentLanguage(SystemLanguage.Vietnamese);
            LocalizeImage.SetCurrentLanguage();
        }
    }
    private IEnumerator SceneAnimal()
    {
        background.SetActive(true);
        logo.SetActive(true);
        loading.SetActive(true);
        async = SceneManager.LoadSceneAsync("Animal");
        yield return async;
    }
    private IEnumerator LoadAsync(int index)
    {
        AsyncOperation normalAsync = SceneManager.LoadSceneAsync(index);
        yield return normalAsync;
    }
    void Update()
    {
        if(async != null)
        {
            imageComp.fillAmount = async.progress;
            int a = (int)(imageComp.fillAmount * 100);
            if (a > 0 && a <= 33)
            {
                if(PlayerPrefs.GetInt("language") == 0)
                    textNormal.text = "Chờ tí bạn nhé!!!";
                else
                    textNormal.text = "Wait a minute!!!";
            }
            else if (a > 33 && a <= 67)
            {
                if (PlayerPrefs.GetInt("language") == 0)
                    textNormal.text = "Đợi tí xíu thôi!!!";
                else
                    textNormal.text = "Wait a minute!!!";
            }
            else if (a > 67 && a < 100)
            {
                if (PlayerPrefs.GetInt("language") == 0)
                    textNormal.text = "Sắp xong rồi nè!!!";
                else
                    textNormal.text = "Almost done!!!";
            }
            else
            {
                if (PlayerPrefs.GetInt("language") == 0)
                    textNormal.text = "Xong rồi vô thôi!!!";
                else
                    textNormal.text = "Yah!!!Done.";
            }
            text.text = a + "%";
        }
    }
}

