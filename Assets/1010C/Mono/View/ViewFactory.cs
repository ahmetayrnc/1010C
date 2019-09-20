using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ViewFactory : MonoBehaviour
{
    private static ViewFactory _inst;

    private static ViewFactory Instance
    {
        get
        {
            if (_inst) return _inst;

            _inst = FindObjectOfType<ViewFactory>();
            Debug.Assert(_inst != null, "No ViewFactory in scene");

            return _inst;
        }
    }

    public GameObject cubeView;

    public static GameObject SpawnCube()
    {
        return Instance.SpawnCubeInternal();
    }

    private GameObject SpawnCubeInternal()
    {
        return Instantiate(cubeView);
    }
}