using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set3DModel : Node {

    private _3DObject comp;
    public Set3DModel() : base(NodeType.Function) {
        addInputPin(new PinValue()); //game object    
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

        _3DObject _3dobj = inputPins[0].get();
        string modelname = inputPins[1].get();

        string path = "ARModels/" + modelname;
        Transform t = (Transform)Resources.Load(path, typeof(Transform));
        MeshFilter mf = t.GetComponent<MeshFilter>();
        MeshRenderer mr = t.GetComponent<MeshRenderer>();
        

        _3dobj.mesh_filter.mesh = mf.sharedMesh;
        _3dobj.mesh_renderer.sharedMaterials = mr.sharedMaterials;
        
        
        Debug.Log("Loaded 3D Model: " + path);

        outputPins[0].run();
    }
}