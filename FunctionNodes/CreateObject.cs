using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : Node {

    public CreateObject() : base(NodeType.Function) {
        addInputPin(new PinValue()); //parent      
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override void run(){

        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }


        GameObject obj = inputPins[0].get();
        Transform parent = obj.transform;
        
        GameObject objToSpawn = new GameObject();
        objToSpawn.transform.parent = parent;
        Debug.Log("Object created!");
        
        outputPins[0].run();
    }
}