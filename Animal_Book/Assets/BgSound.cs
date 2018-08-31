using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSound : MonoBehaviour {
    public AudioClip clip;
    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.loop = true;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
