using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
    public GameObject Target; // The object that add this script, rotate around this object.
    List<AnimationState> listState = new List<AnimationState>();
    Animation anim;
    private float speed= 20f;
    bool isMoving;
    bool isClick;
    private int index;
	// Use this for initialization
	void Awake () {
        isMoving = true;
        isClick = true;
        anim = GetComponent<Animation>();
        foreach(AnimationState state in anim)
        {
            listState.Add(state);
        }
	}
	
	// Update is called once per frame
	void Update () {
        RotateAroundAObject();
        if ((Input.GetMouseButtonDown(0) || Input.touchCount == 1) && isClick)
        {
            isMoving = false;
            index = Random.Range(2, 5);
        }
        if (isMoving)
        {
            anim.Play(listState[1].name);
            speed = 20f;
            isClick = true;
        }
        else
        {
            anim.Play(listState[index].name);
            speed = 0f;
            StartCoroutine(BacktoWalk()); // after animation 5 second, player keep moving and can't click to a few time
        }
	}
    void RotateAroundAObject() // The function make a object rotate around a specific object.
    {
        transform.RotateAround(Target.transform.position, Vector3.up, -speed * Time.deltaTime);
    }
    IEnumerator BacktoWalk()
    {
        yield return new WaitForSeconds(5.0f);
        isMoving = true;
        isClick = false;
    }
}
