using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.VR.WSA.Input;
using UnityEngine.VR.WSA.Persistence;
using UnityEngine.VR.WSA;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;


public class InputTapHandler : Singleton<InputTapHandler>, IInputClickHandler
{
    public PrefabSpawnManager spawnManager;
    private bool scaledUp = false;
    public GameObject cityBase;  // this is what is going to be scaled up. 
    void Start()
    {
        InputManager.Instance.ClearFallbackInputStack();
        InputManager.Instance.PushFallbackInputHandler(gameObject); // 

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (SharingStage.Instance.IsConnected)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                SpawnCity();
            }
            if (rnd == 1)
            {
                SpawnTree();
            }
            if(rnd == 2)
            {
                SpawnRoad();
            }
        }

        GameObject.FindWithTag("AnchorText").GetComponent<Renderer>().enabled = false;
    }

    public void SpawnCity()
    {
        if (cityBase == null)
        {
            return;
        }
        if (CheckScaledUp())
        {
            return;
        }
        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
(GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
        newCubePosition = new Vector3(newCubePosition.x, cityBase.transform.position.y + 0.4f, newCubePosition.z);
        this.spawnManager.Spawn(
         new SyncSpawnedObject(),
         newCubePosition,
         Quaternion.identity,
         cityBase,
         "My Obj",
         false);
    }

    public void SpawnTree()
    {
        if (cityBase == null)
        {
            return;
        }
        if (CheckScaledUp())
        {
            return;
        }
        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
         (GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
        newCubePosition = new Vector3(newCubePosition.x, cityBase.transform.position.y + 0.4f, newCubePosition.z);
        this.spawnManager.Spawn(
         new SyncBaseTree(),
         newCubePosition,
         Quaternion.identity,
         cityBase,
         "My Obj",
         false);
    }

    public void SpawnRoad()
    {
        if(cityBase == null)
        {
            return;
        }
        if (CheckScaledUp()){
            return;
        }

        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
         (GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
        newCubePosition = new Vector3(newCubePosition.x, cityBase.transform.position.y + 0.4f, newCubePosition.z);
        this.spawnManager.Spawn(
         new SyncBaseRoad(),
         newCubePosition,
         Quaternion.identity,
         cityBase,
         "My Obj",
         false);


    }

    public void CreateGrid()
    {
        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
 (GazeManager.Instance.GazeOrigin +Vector3.down*0.35f+ GazeManager.Instance.GazeNormal * 2.0f));
        this.spawnManager.Spawn(
         new SyncBaseGrid(),
         newCubePosition,
         Quaternion.identity,
         cityBase,
         "My Obj",
         false);
        //Deactivate the grid text mesh renderer
        cityBase = GameObject.FindWithTag("Grid");
        GameObject.FindWithTag("Grid").GetComponent<GridInitialization>().SnapGrid();
        GameObject.FindWithTag("AnchorText").GetComponent<Renderer>().enabled = false;
    }

    public void ScaleCityUp()
    {
        cityBase.transform.localScale = new Vector3(40, 40, 40);
        scaledUp = true;
    }
    public void ScaleCityDown()
    {
        cityBase.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        scaledUp = false;
    }

    private bool CheckScaledUp()
    {
        if(cityBase.transform.localScale == new Vector3(40, 40, 40))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}





