using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour {
    List<AnimationState> animStates = new List<AnimationState>();
    Animation anim;
    private float time;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        foreach(AnimationState state in anim)
        {
            animStates.Add(state);
        }
	}
	void RandomAnim()
    {
        time += Time.deltaTime;
        if(time > 3)
        {
            int index = Random.Range(0, 5);
            anim.Play(animStates[index].name);
            time = 0;
        }
    }
	// Update is called once per frame
	void Update () {
        RandomAnim();
	}
}
