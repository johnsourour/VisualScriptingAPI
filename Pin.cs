using System.IO;
using System;
using System.Collections.Generic;

public enum PinDataType {
    Execution,
    Number,
    Integer,
    String,
    AROjbect,
    ProjectionMap,
    Image
}

public abstract class Pin{
    private string type;
    private int pin_id; 

    public Node source; // source node 
    public static int id_count = 0; //global pin counter
    public Pin(){
    }
    public Pin(string _type){
        type = _type;
        pin_id = id_count++; 
    }
    public int getID(){
        return pin_id;
    }
    public string getType(){
      return type;
    }
}

public class Pin <T> : Pin{
    private T value;
    public Pin() : base(typeof(T).Name){
        
    }
    public Pin(T _value) : base(typeof(T).Name){
        value=_value;
    }
    public void set(T v){
        value=v;
    }
    public T get() {
        return value;
    }
}