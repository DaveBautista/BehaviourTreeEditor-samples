using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum NodeStatus
{
    FAILURE,
    SUCCESS,
    RUNNING
}

public abstract class BehaviourState
{

}

public abstract class Node
{
    public bool starting = true;
    protected bool debug = false;
    public int ticks = 0;
    public static List<string> debugTypeBlacklist = new List<string>() { "Selector", "Sequence", "Repeater", "Inverter", "Succeeder" };
    public virtual NodeStatus Update(BehaviourState State)
    {
        NodeStatus ret = OnUpdate(State);

        if (debug && !debugTypeBlacklist.Contains(GetType().Name))
        {
            string result = "Unknown";
            switch (ret)
            {
                case NodeStatus.SUCCESS:
                    result = "Success";
                    break;
                case NodeStatus.FAILURE:
                    result = "Failure";
                    break;
                case NodeStatus.RUNNING:
                    result = "Running";
                    break;
            }
            Debug.Log("Behaving: " + GetType().Name + " - " + result);
        }

        ticks++;
        starting = false;
        if (ret != NodeStatus.RUNNING)
            Reset();

        return ret;
    }

    public abstract NodeStatus OnUpdate(BehaviourState state);
    public void Reset()
    {
        starting = true;
        ticks = 0;
        OnReset();
    }

    public abstract void OnReset();
}

public abstract class Composite : Node
{
    protected List<Node> children = new List<Node>();
    public string compositeName;

    public Composite(string name, params Node[] nodes)
    {
        compositeName = name;
        children.AddRange(nodes);
    }

    public override NodeStatus Update(BehaviourState state)
    {
        bool shouldLog = debug && ticks == 0 ? true : false;
        if (shouldLog)
            Debug.Log("Running behaviour list: " + compositeName);

        NodeStatus ret = base.Update(state);

        if (debug && ret != NodeStatus.RUNNING)
            Debug.Log("Behaviour list " + compositeName + " returned: " + ret.ToString());

        return ret;
    }
}

public abstract class Leaf : Node
{

}

public abstract class Decorator : Node
{
    protected Node child;

    public Decorator (Node node)
    {
        child = node;
    }
}
