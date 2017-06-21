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
    }

    private void SpawnCity()
    {
        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
(GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
        this.spawnManager.Spawn(
         new SyncSpawnedObject(),
         newCubePosition,
         Quaternion.identity,
         this.gameObject,
         "My Obj",
         false);
    }

    private void SpawnTree()
    {
        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
         (GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
        this.spawnManager.Spawn(
         new SyncBaseTree(),
         newCubePosition,
         Quaternion.identity,
         this.gameObject,
         "My Obj",
         false);
    }

    private void SpawnRoad()
    {
        var newCubePosition = this.gameObject.transform.InverseTransformPoint(
         (GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
        this.spawnManager.Spawn(
         new SyncBaseRoad(),
         newCubePosition,
         Quaternion.identity,
         this.gameObject,
         "My Obj",
         false);
    }






}




