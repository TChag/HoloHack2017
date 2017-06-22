using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Unity.InputModule;

public class SnappingManager : MonoBehaviour {

    public bool onGrid;
    private CubeDragger cubeDragger;

    private AudioSource audioSource;
    public AudioClip a_spawn;
    public AudioClip a_placed;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        cubeDragger = GetComponent<CubeDragger>();
        PlaySpawnAudio();
    }
    // Update is called once per frame
    void Update () {
        //if (onGrid && cubeDragger.isDragging)
        //{
        //    transform.position = new Vector3(
        //        Snap(transform.position.x),
        //        GridInitialization.Grid.position.y,
        //        Snap(transform.position.z));
        //}
        
	}

    public void SnapToGrid()
    {
        transform.position = new Vector3(
                Snap(transform.position.x),
                GridInitialization.Grid.position.y,
                Snap(transform.position.z));
        Debug.Log(onGrid);
        if (onGrid)
        {
            Debug.Log("activating animation");
            GetComponentInChildren<AnimationPlayer>().PlayAnimation();
            audioSource.PlayOneShot(a_placed);
        }
    }

    public void PlaySpawnAudio()
    {
        audioSource.PlayOneShot(a_spawn);
    }


    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag == "Grid")
        {
            onGrid = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
  
        if (other.tag == "Grid")
        {
            onGrid = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Grid")
        {
            onGrid = true;
        }
    }

    private float Snap(float f)
    {
        return (float)Math.Round(f, 1);
    }
}
