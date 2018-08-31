using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public AudioClip btnClickedSound; //audioclip for buttons
	public string nextLevelName = ""; //if exist what is the next level name in order to navigate to it?
	public Sprite btnActive; //sprite representing active state of button
	private SpriteRenderer spriteRenderer;
	private Sprite initialSpite;

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		initialSpite = this.GetComponent<SpriteRenderer>().sprite; //save piece's sprite to an initial variable
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		if(nextLevelName=="")
			nextLevelName = Application.loadedLevelName; //if no other level name is provided in the inspector then next level for load will be current level
	}

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	void OnMouseDown()
	{
		spriteRenderer.sprite = btnActive;
		PlayAudioButtons();	
		GoToNextLevel(nextLevelName);
	}

	/// <summary>
	/// Raises the mouse up event.
	/// </summary>
	void OnMouseUp()
	{
		spriteRenderer.sprite = initialSpite; //reset the button sprite to its initial normal state
	}
	
	/// <summary>
	/// Plaies the audio buttons.
	/// </summary>
	void PlayAudioButtons()
	{
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().clip = btnClickedSound;
		GetComponent<AudioSource>().Play();
	}

	/// <summary>
	/// Nexts the level.
	/// </summary>
	/// <param name="levelName">Level name.</param>
	void GoToNextLevel(string levelName)
	{
		Application.LoadLevel(levelName); 
	}
}
