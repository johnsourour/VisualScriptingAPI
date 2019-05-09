using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : Node {
    GameObject objspawned;

    public CreateObject() : base(NodeType.Function) {
        addInputPin(new PinValue()); //parent      
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        return inputPins[0].exists();
    }

    public override dynamic get(uint pinID) {
        return objspawned;
    }
    
    public override void run(){

        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }


        string objname = inputPins[0].get();
        Transform parent = scriptContainer.contentArea;
        
        objspawned = new GameObject(objname);
        objspawned.transform.parent = parent;
        Debug.Log("Object created!");
        
        outputPins[0].run();
    }
}