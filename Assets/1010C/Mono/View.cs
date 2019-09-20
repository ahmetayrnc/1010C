using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView
{
    public void Link(IEntity entity)
    {
        gameObject.Link(entity);
    }
}
