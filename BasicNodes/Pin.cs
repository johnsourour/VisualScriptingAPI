using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTarget {
    public Node source;
    public uint nodeID;
    public uint pinID;

    public PinTarget(Node s, uint p) {
        source = s;
        pinID = p;
    }
    public PinTarget(uint n, uint p) {
        nodeID = n;
        pinID = p;
    }
};

public abstract class Pin {
    protected PinDataType type;
    public PinTarget source = null;
    
    public Pin(){}
    public Pin(uint nodeID, uint pinID, PinDataType typ) {
        source = new PinTarget(nodeID, pinID);
        type = typ;
    }
    public Pin(Node src, uint pinID, PinDataType typ) {
        source = new PinTarget(src, pinID);
        type = typ;
    }
    
    public PinDataType getType(){
        return type;
    }

    public bool exists() {
        return source != null && source.source != null;
    }
}

public class PinValue : Pin {

    public PinValue(){}
    public PinValue(Node s, uint p, PinDataType d) : base(s, p, d) {}
    public PinValue(uint n, uint p, PinDataType d) : base(n, p, d) {}
    
    public dynamic get() {
        return source.source.get(source.pinID);
    }
}

public class PinExecutable : Pin {


    public PinExecutable(){}

    public PinExecutable(Node s, uint p) : base(s, p, PinDataType.Execution) {}
    public PinExecutable(uint n, uint p) : base(n, p, PinDataType.Execution) {}

    public void run() {
        if(exists())
            source.source.run();
    }
}