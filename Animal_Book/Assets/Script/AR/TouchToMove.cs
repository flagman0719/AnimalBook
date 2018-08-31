using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour {
    [SerializeField]
    private float speed;
    public AudioClip clip;
    AudioSource source;
    List<AnimationState> animState = new List<AnimationState>();
    private Animation anim; 
    Vector3 targetPos; // This is position click or touch on screen.
    bool isMoving;

    void Awake()
    {
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim) // Add animations in component to list animation state.
        {
            animState.Add(state);
        }
    }

	// Use this for initialization
	void Start () {
        source = gameObject.GetComponent<AudioSource>();
        //source.PlayOneShot(clip);
        anim.Play(animState[0].name); // Animation Idle
        isMoving = false;
        targetPos = transform.position; // Default set Target Position is position of object.
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) || Input.touchCount == 1) // if click or touch
        {
            SetTargetPosition(); // Set target position is the position click or touch on screen.
        }
        if(isMoving)
        {
            anim.Play(animState[1].name); // Animation Walk
            MovePlayer(); // Move object to target position
        }
	}
    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray;
        if(Application.platform == RuntimePlatform.Android) // whhen runtime app is Android app
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        }
        else // when run in Unity Editor or click mouse
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        float point = 0f;
        if (plane.Raycast(ray, out point))
            targetPos = ray.GetPoint(point);
        isMoving = true;
    }
    void MovePlayer()
    {
        transform.LookAt(targetPos); // rotate follow Target Position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        float value = (targetPos.x - transform.position.x) + (targetPos.z - transform.position.z);

        if (value < 0.01 && value > -0.01)
        {
            //source.PlayOneShot(clip);
            int index = Random.Range(2, 4); // Random animation
            anim.Play(animState[index].name);
            //StartCoroutine(AnimationBite());
            isMoving = false;
        }
    }
    IEnumerator AnimationBite()
    {
        yield return new WaitForSeconds(3.0f);
        anim.Play(animState[0].name);
    }
}
