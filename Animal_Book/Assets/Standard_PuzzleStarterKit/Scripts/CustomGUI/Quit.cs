using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	public AudioClip btnClickedSound; //audioclip for buttons
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
	}

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	void OnMouseDown()
	{
		spriteRenderer.sprite = btnActive;
		PlayAudioButtons();
		Application.Quit();
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
}
