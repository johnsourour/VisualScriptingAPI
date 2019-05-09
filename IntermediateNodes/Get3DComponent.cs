using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Dynamic;

public class Get3DComponent : Node {

    public Get3DComponent() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //game object      
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        GameObject obj = inputPins[0].get();
        
        MeshFilter mesh_filter = obj.GetComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mesh_renderer = obj.GetComponent(typeof(MeshRenderer)) as MeshRenderer;

        
        Debug.Log("Got 3D Component");

        return new _3DObject(mesh_filter, mesh_renderer);
        
    }

    
}