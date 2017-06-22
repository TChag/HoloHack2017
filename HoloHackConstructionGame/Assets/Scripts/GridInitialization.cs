using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridInitialization : MonoBehaviour {


    public static Transform Grid;

    private void OnEnable()
    {
        //Grid = this.transform;

        //transform.position = new Vector3(
        //    Snap(transform.position.x),
        //    Snap(transform.position.y),
        //    Snap(transform.position.z));
    }

    public void SnapGrid()
    {
        Grid = this.transform;

        transform.position = new Vector3(
            Snap(transform.position.x),
            Snap(transform.position.y),
            Snap(transform.position.z));
    }
    private float Snap(float f)
    {
        return (float)Math.Round(f, 1);
    }
}
