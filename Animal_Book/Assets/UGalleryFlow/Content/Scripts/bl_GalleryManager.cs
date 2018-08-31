using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class bl_GalleryManager : MonoBehaviour
{
    //AudioSource source;
    //public AudioClip nen;
    public List<bl_UGFInfo> m_Items = new List<bl_UGFInfo>();
    [Header("FullWindow")]
    public GameObject FullWindowRoot = null;
    public Image m_FullIcon = null;
    public Text m_TxtName = null;
    public Text m_txtLoai = null;
    public Text m_txtInfo = null;
    private Texture2D imgTexture;
    public Button FullButtonOption = null;
    [Header("References")]
    public GameObject ItemPrefab = null;
    public Transform GalleryPanel = null;
    [SerializeField]private ScrollRect ScrollList;
    private AnOtherFeaturesPreview NativeCamera;
    public const string UGFName = "UGalleryManager";
    private List<bl_GalleryItem> cacheGallery = new List<bl_GalleryItem>();

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        //source = gameObject.GetComponent<AudioSource>();
        //source.clip = nen;
        //source.loop = true;
        //source.Play();
        NativeCamera = GetComponent<AnOtherFeaturesPreview>();
        this.gameObject.name = UGFName;
        InstanceItems();
    }
    /// <summary>
    /// Instance all items UI to the panel in canvas
    /// with the information of each in list
    /// </summary>
    void InstanceItems()
    {
        for (int i = 0; i < m_Items.Count; i++)
        {
            GameObject item = Instantiate(ItemPrefab) as GameObject;
            bl_GalleryItem gi = item.GetComponent<bl_GalleryItem>();
            gi.GetInfo(m_Items[i].m_VieNametxt, m_Items[i].m_VieLoaitxt, m_Items[i].m_VieInfotxt, m_Items[i].m_EngNametxt, m_Items[i].m_EngLoaitxt, m_Items[i].m_EngInfotxt, m_Items[i].m_ItemIcon, m_Items[i].imgTexture, m_Items[i].m_onClick);
            item.transform.SetParent(GalleryPanel, false);
            cacheGallery.Add(gi);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        //float scrollPos = ScrollList.horizontalNormalizedPosition;
        for(int i = 0; i < cacheGallery.Count; i++)
        {
           if(cacheGallery[i] != null) cacheGallery[i].OnUpdate();
        }
    }
    public void DownloadImage()
    {
        NativeCamera.SaveToGalalry(imgTexture);
    }
    public void GoToSideList(bool left)
    {
        StopAllCoroutines();
        StartCoroutine(IEMoveSide(left));
    }
    
    /// <summary>
    /// Get information from the item clicked and send to the full window to open
    /// </summary>
    public void FullWindow(bool show, string mName = "", string mLoai ="", string mInfo="", Sprite ico = null, Texture2D imgtex = null, Button.ButtonClickedEvent e = null)
    {
        //Debug.Log(mName + mLoai + mInfo);
        m_FullIcon.sprite = ico;
        m_TxtName.text = mName;
        m_txtLoai.text = mLoai;
        m_txtInfo.text = mInfo;
        imgTexture = imgtex;
        //changeName.localizationKey = mName;
        //changeLoai.localizationKey = mLoai;
        //changeInfo.localizationKey = mInfo;
        bool act = false;
        if (e != null)
        {
            //if the event of item have at least event to call
            //then active the button, if not, disabled.
            act = (e.GetPersistentEventCount() > 0) ? true : false;
        }
        FullButtonOption.gameObject.SetActive(act);
        FullButtonOption.onClick = e;//send the event list to the button
        FullWindowRoot.SetActive(show);
    }
    /// <summary>
    /// 
    /// </summary>
    public void ClosetFullWindow() { FullWindow(false); }

    IEnumerator IEMoveSide(bool left)
    {
        if (left)
        {
            while(ScrollList.horizontalNormalizedPosition > 0)
            {
                ScrollList.horizontalNormalizedPosition -= Time.deltaTime;
                yield return null;
            }
        }else
        {
            while (ScrollList.horizontalNormalizedPosition < 1)
            {
                ScrollList.horizontalNormalizedPosition += Time.deltaTime;
                yield return null;
            }
        }
    }
}