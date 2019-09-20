using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TestSystem : IExecuteSystem
{
    public TestSystem(Contexts contexts)
    {
    }

    public void Execute()
    {
        Debug.Log("test");
    }
}