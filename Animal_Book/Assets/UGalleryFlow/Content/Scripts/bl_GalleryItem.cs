using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DFTGames.Localization;
public class bl_GalleryItem : MonoBehaviour
{

    [HideInInspector]public bool OnCenter = false;
   
    [Header("Settings")]
    [Range(0, 0.5f)]
    public float CrossFadeAnim = 0.4f;
    [Header("Effects")]
    public UGFType m_Type = UGFType.Reflection;
    public Image Reflection = null;
    private DFTGames.Localization.Localize changename;
    [Header("References")]
    [SerializeField]private CanvasGroup GroupAlpha;
    [SerializeField]private Animator ContentAnim;

    public Image Icon;
    public Text txtName;
    private string strName, strLoai, strInfo;
    private bl_GalleryManager mGalleryManager;
    private Texture2D imgTex;
    private bl_GalleryManager m_Manager { get { if (mGalleryManager == null) { mGalleryManager = GameObject.Find(bl_GalleryManager.UGFName).GetComponent<bl_GalleryManager>(); } return mGalleryManager; } }
    private Button.ButtonClickedEvent events = new Button.ButtonClickedEvent();//cache event of item
    private float currentAlpha = 1;

    /// <summary>
    /// 
    /// </summary>
    IEnumerator Start()
    {
        changename = txtName.GetComponent<DFTGames.Localization.Localize>();
        yield return new WaitForSeconds(0.1f);
        if(ScreenHorizontalPosition > 0.52f || ScreenHorizontalPosition < 0.48f)
        {
            Animation a = this.GetComponent<Animation>();
            //For that side is exit the UI?
            if (isRightPosition)
            {
                a.CrossFade("OnExitR", CrossFadeAnim);
            }
            else
            {
                a.CrossFade("OnExitL", CrossFadeAnim);
            }
        }
    }

    /// <summary>
    /// When the UI enter or exit from the center
    /// </summary>
    public void CenterEvent(bool b)
    {
        Animation a = this.GetComponent<Animation>();
        if (a == null)
        {
            Debug.LogError("This don't have Animation component");
            return;
        }
        //When enter
        if (b)
        {
            if (isRightPosition)
            {
                a.CrossFade("OnCenterR", CrossFadeAnim);
            }
            else
            {
                a.CrossFade("OnCenterL", CrossFadeAnim);
            }
        }
        else//When Exit
        {
            //For that side is exit the UI?
            if (isRightPosition)
            {
                a.CrossFade("OnExitR", CrossFadeAnim);
            }
            else
            {
                a.CrossFade("OnExitL", CrossFadeAnim);
            }
        }
    }

    /// <summary>
    /// Cache info of item from the gallery manager
    /// </summary>
    public void GetInfo(string vietxtname, string vietxtloai, string vietxtinfo, string engtxtname, string engtxtloai, string engtxtinfo, Sprite ico, Texture2D imgtex, Button.ButtonClickedEvent e)
    {
        //Debug.Log(changename);
        if(PlayerPrefs.HasKey("language"))
        {
            switch(PlayerPrefs.GetInt("language"))
            {
                case 0:
                    {
                        txtName.text = vietxtname;
                        strName = vietxtname;
                        strLoai = vietxtloai;
                        strInfo = vietxtinfo;
                        break;
                    }
                case 1:
                    {
                        txtName.text = engtxtname;
                        strName = engtxtname;
                        strLoai = engtxtloai;
                        strInfo = engtxtinfo;
                        break;
                    }
            }
        }
        Icon.sprite = ico;
        imgTex = imgtex;
        events = e;
        if (Reflection != null)
        {
            if (m_Type == UGFType.Reflection)
            {
                Reflection.sprite = ico;
            }
            else if (m_Type == UGFType.Shadown)
            {
                Reflection.color = Color.black;
            }
            else
            {
                Reflection.gameObject.SetActive(false);
            }
        }
        CenterEvent(false);
    }

    /// <summary>
    /// when clicked the item, send information for open the full window
    /// </summary>
    public void OpenFullWindow()
    {
        //just when this is the target (in center), can open
        if (!OnCenter)
            return;//if not in center, just return.
        //Debug.Log(strName + strLoai + strInfo);
        m_Manager.FullWindow(true, strName,strLoai,strInfo, Icon.sprite, imgTex, events);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnUpdate()
    {
        float pos = ScreenHorizontalPosition;
        if (pos < 0.45f || pos > 0.55f)
        {
            if (isRightPosition)
            {
                currentAlpha = 1 - pos;
            }else
            {
                currentAlpha = pos;
            }
        }
        else
        {
            currentAlpha = 1;
        }
        GroupAlpha.alpha = Mathf.Lerp(GroupAlpha.alpha, currentAlpha, Time.deltaTime * 10);


    }

    /// <summary>
    /// Get the side (Left or Right) of UI into the screen
    /// </summary>
    private bool isRightPosition
    {
        get
        {
            return (ScreenHorizontalPosition > 0.5f);
        }
    }

    public float ScreenHorizontalPosition
    {
        get
        {
            Camera c = (Camera.main != null) ? Camera.main : Camera.current;
            Vector2 viewpoint = c.WorldToViewportPoint(transform.position);

            return viewpoint.x;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    public void OnMouseEvent(bool e)
    {

        ContentAnim.SetBool("select", e);
    }

    private RectTransform m_Rect = null;
    private RectTransform mRect
    {
        get
        {
            if (m_Rect == null)
            {
                m_Rect = this.GetComponent<RectTransform>();
            }
            return m_Rect;
        }
    }

    private RectTransform m_ParentRect = null;
    private RectTransform ParentRect
    {
        get
        {
            if (m_ParentRect == null)
            {
                m_ParentRect = this.GetComponent<Transform>().parent.GetComponent<RectTransform>();
            }
            return m_ParentRect;
        }
    }
}