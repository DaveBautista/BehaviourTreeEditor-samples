using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderOrChaseBT : MonoBehaviour {
 
    // ---------------------------------------------------------
    // REMEMBER: THIS IS AN AUTO-GENERATED TEMPLATE
    // For the tree to function, the code must be manually fixed
    // ---------------------------------------------------------
 
 
    Node behaviourTree;
    Context behaviourState = new Context();
 
    private void Start()
    {
       behaviourTree = CreateBehaviourTree();
       behaviourState = new Context();
    }
 
    private void FixedUpdate()
    {
       behaviourTree.Update(behaviourState);
    }
 
    private Node CreateBehaviourTree()
    {
       // Choose to wander or to chase the currently linked target
       //Selector WanderOrChase = new Selector(WanderOrChase,
           //Wander,
           //ChaseTarget);

       // Check if i have a target, and if it is too far away, then chase it
       //Sequence ChaseTarget = new Sequence(ChaseTarget,
           //new HasTarget(),
           //new Inverter(new TooCloseToTarget(),
           //new ChaseTarget());

       // Set a random destination and move to it
       //Sequence Wander = new Sequence(Wander,
           //new SetRandomDestination(),
           //new Move());


           //Repeater root = new Repeater(Root);

           //return root;

           // Remove this line when template has been correctly implemented
           return null;
    }
}
