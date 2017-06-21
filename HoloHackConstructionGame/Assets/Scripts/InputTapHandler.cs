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
            var newCubePosition =
        this.gameObject.transform.InverseTransformPoint(
          (GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 2.0f));
            this.spawnManager.Spawn(
        new SyncSpawnedObject(),
        newCubePosition,
        Random.rotation,
        this.gameObject,
        "MyCube",
        false);
        }
    }
}

    


