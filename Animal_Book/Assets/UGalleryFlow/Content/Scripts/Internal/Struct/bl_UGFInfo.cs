using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class bl_UGFInfo {

    public string m_VieNametxt = "";
    public string m_VieLoaitxt = "";
    public string m_VieInfotxt = "";
    public string m_EngNametxt = "";
    public string m_EngLoaitxt = "";
    public string m_EngInfotxt = "";
    public Sprite m_ItemIcon = null;
    public Texture2D imgTexture = null;
    [Header("onClick")]
    public Button.ButtonClickedEvent m_onClick = new Button.ButtonClickedEvent();

}