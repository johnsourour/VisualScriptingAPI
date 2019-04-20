using System;
using System.Collections.Generic;

public abstract class Pin{
    string pin_type;
}

public class Pin <T> : Pin{
    private T value;
    public void set(T v){
        value=v;
    }
    public T get(){
        return value;
    }
}