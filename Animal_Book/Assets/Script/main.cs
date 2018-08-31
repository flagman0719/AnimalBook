using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {
    public Text txt;
    public GameObject animal;
    public GameObject btn;
    private float speed = 3f;
    Animation anim;
    List<AnimationState> states = new List<AnimationState>();
    int index = 3;
    bool isrun = false ;
    AudioSource source;
    public AudioClip[] AudioArray;
	// Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        GetAnimation();
        transform.position = new Vector3(-12, transform.position.y, transform.position.z);
        source = gameObject.GetComponent<AudioSource>();
       // sourceArray = gameObject.GetComponents<AudioSource>();
       // source.clip = sourceArray[3].clip;
        //source.loop = true;
        source.pitch = 1f;
        source.PlayOneShot(AudioArray[0]);
        txt.text = "Elephant";

    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (transform.position.x >= 0 && isrun == false)
        {
            speed = 0;
            anim.Play(states[4].name, PlayMode.StopAll);
           // source.Stop();
            //source.clip = sourceArray[4].clip;
           // source.loop = true;
           // source.pitch = 1f;
        }
        else
        {
            anim.Play(states[3].name, PlayMode.StopAll);
            speed = 3f;

        }
        if (transform.position.x >= 12)
        {
            txt.text = "";
            Destroy(gameObject);
            animal.SetActive(true);
            isrun = false;
        }

	}
    public void NextAnimal()
    {
        isrun = true;
        source.Stop();
        source = gameObject.GetComponent<AudioSource>();
        source.PlayOneShot(AudioArray[0]);
        btn.SetActive(true);
    }
    public void GetAnimation()
    {
        foreach (AnimationState state in anim)
        {
            states.Add(state);
        }
        Debug.Log(states.Count);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "sound")
        {
            //Debug.Log("Playsound");
            source = gameObject.GetComponent<AudioSource>();
            source.clip = AudioArray[1];
            source.loop = true;
            source.Play();
        }
        if (target.gameObject.tag == "animalname")
        {
            source.PlayOneShot(AudioArray[2]);
        }
    }
}
