using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {


    public Animation anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Q))
            PlayAnimation();
    }

    public void PlayAnimation()
    {
        anim["textAnim"].time = 0;
        anim.Play("textAnim");
    }
}
