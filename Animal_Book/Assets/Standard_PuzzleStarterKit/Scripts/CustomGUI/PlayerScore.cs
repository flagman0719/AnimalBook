using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public GameObject menuWindow;
	private int level = 1; //player score
	bool oneTimeIncrementOnLevel; //prevent further increments on player score when enLevel condition is fullfil

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		EndLevel();
	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		oneTimeIncrementOnLevel = true;
		level = PlayerPrefs.GetInt("Score"); //Returns the value corresponding to key in the preference file if it exists.
		gameObject.GetComponent<Renderer>().sortingLayerID = 3; //assign GUI layer to the "level" object.
		gameObject.GetComponent<Renderer>().sortingOrder = 0;
	}
	
	/// <summary>
	/// Ends the level.
	/// </summary>
	void EndLevel()
	{
		this.GetComponent<TextMesh>().text = level.ToString(); //update player score.
		//search for any object with the tag as "shadow" and if there is none then all the pieces are in their spots (on their shadows)
		//also check if oneTimeIncrementOnLevel is true
		if(GameObject.FindGameObjectWithTag("shadow")==null && oneTimeIncrementOnLevel)
		{
			level++; //increment de level with one unit
			PlayerPrefs.SetInt("Score", level); //Sets the value of the preference identified by key
			if(!menuWindow.activeSelf)
				menuWindow.SetActive(true);
			oneTimeIncrementOnLevel = false; //reset oneTimeIncrementOnLevel to false 
		}
	}
}
