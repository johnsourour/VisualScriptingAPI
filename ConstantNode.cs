using System.IO;
using System;
using System.Collections.Generic;

public class Constant <T> : Node {
    private T value;
    
    public Constant(){}
    public Constant(T _value){
        value=_value;
        base.setType("Constant")
    }
    public T get(){
        return value;
    }
}