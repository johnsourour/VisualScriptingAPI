using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create3DComponent : Node {

    private _3DObject comp;
    public Create3DComponent() : base(NodeType.Function) {
        addInputPin(new PinValue()); //game object      
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
        MeshFilter mf = obj.AddComponent<MeshFilter>();
        MeshRenderer mr = obj.AddComponent<MeshRenderer>();
        comp = new _3DObject(mf, mr);
        
        outputPins[0].run();
    }

    public override dynamic get(uint pinID){
        return comp;
    }
}