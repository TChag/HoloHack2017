using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnappingManager : MonoBehaviour {

    private bool onGrid;
    private Transform grid;
    private float gridSize = 0.1f;

	// Use this for initialization
	void Start () {
        grid = GameObject.FindWithTag("Grid").transform;

        grid.position = new Vector3(
            Snap(grid.position.x),
            Snap(grid.position.y),
            Snap(grid.position.z));
    }
	
	// Update is called once per frame
	void Update () {
        if (onGrid)
        {
            this.transform.position = new Vector3(Snap(transform.position.x), grid.transform.position.y, Snap(transform.position.z));
        }
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

    private float Snap(float f)
    {
        return (float)Math.Round(f, 1);
    }
}
