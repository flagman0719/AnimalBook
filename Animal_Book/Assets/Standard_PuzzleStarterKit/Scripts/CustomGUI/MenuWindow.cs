using UnityEngine;
using System.Collections;

public class MenuWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Initialize()
	{
		this.gameObject.SetActive(false); //initialize the main menu as "invisible"
	}
}
