using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public interface IEventContext
{

}

public interface IChoiceContext
{

}

public interface AbilityUnit
{

}

//public abstract class ProcessNode<U, V> : INode<U, V>
//{
//    public bool IsDone { get; set; }

//    public abstract bool CanExecute();

//    public abstract void Tick(float deltaTime);

//    public abstract U Input { get; set; }
//    public abstract V Output { get; set; }
//}

//public abstract class EntryNode<V> : ProcessNode<IEventContext, V>
//{

//}

//public interface IOutput<V>
//{
//    public V Output { get; set; }
//}

//public interface IInput<U>
//{
//    public U Input { get; set; }
//}

//public interface INode
//{
//    public bool IsDone { get; set; }

//    public bool CompletePath { get; set; }
//    public abstract bool CanExecute();

//    public abstract void Tick(float deltaTime);
//}
//public interface INode<T> : INode
//{
//    public T Input { get; set; }

//    public void SetInput(T input)
//    {
//        this.Input = input;
//    }
//}
//public interface IMiddleNode<T, V> : INode<T>
//{
//    public INode<V> NextNode { get; set; }
//}

//public interface IEndNode<T> : INode<T>
//{

//}

//public interface IEntryNode<T> : INode<T> where T : IEventContext
//{
//    public List<EdgeConnector> OutEdge { get; set; }
//}

//public interface IEdgeConnector
//{

//}
//public class Ability
//{
//    public List<INode> Nodes { get; set; }
//}

//public interface IPathConnector<U,V>
//{
//    void Tick(float deltaTime);

//}

public interface IDataContext
{

}
public interface IPathConnector
{
    IDataContext ExportDataForNextNode();

    INode NextNode();
}
public interface INode
{
    public List<IPathConnector> Connectors { get; set; }
}
public abstract class EntryNode : IPathConnector
{
    public abstract IDataContext ExportDataForNextNode();
}


public class AbilitySystem : MonoBehaviour
{
    public Queue<AbilityExecuteData> _queue;

    private void Start()
    {

    }
    public void EnqueueAbility(AbilityUnit ability, IEventContext eventContext)
    {

    }
    public void Update()
    {

    }
}

public class AbilityExecuteData
{
    public AbilityUnit ability;
    public IEventContext eventContext;
}