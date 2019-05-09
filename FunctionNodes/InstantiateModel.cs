using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateModel : Node {
    Transform instance;

    public InstantiateModel() : base(NodeType.Function) {
        addInputPin(new PinValue()); //game object
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready() {
        return inputPins[0].exists();
    }

    public override dynamic get(uint pinID) {
        return instance;
    }
    
    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        string modelname = inputPins[0].get();

        string path = "ARModels/" + modelname;
        Transform prefab = (Transform)Resources.Load(path, typeof(Transform));
        instance = GameObject.Instantiate(prefab, scriptContainer.contentArea);
        
        Debug.Log("Instantiate Model: " + path);

        outputPins[0].run();
    }
}