using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTarget {
    public Node source;
    public uint pinID;

    public PinTarget(Node s, uint p) {
        source = s;
        pinID = p;
    }
};

public abstract class Pin {
    protected PinDataType type;
    protected PinTarget source = null;
    
    public Pin(){}
    public Pin(Node src, uint pinID, PinDataType typ) {
        source = new PinTarget(src, pinID);
        type = typ;
    }
    
    public PinDataType getType(){
        return type;
    }

    public bool exists() {
        return source.source != null;
    }
}

public class PinValue : Pin {

    public PinValue(){}
    public PinValue(Node s, uint p, PinDataType d) : base(s, p, d) {}
    
    public dynamic get() {
        return source.source.get(source.pinID);
    }
}

public class PinExecutable : Pin {


    public PinExecutable(){}

    public PinExecutable(Node s, uint p) : base(s, p, PinDataType.Execution) {}

    public void run() {
        if(exists())
            source.source.run();
    }
}