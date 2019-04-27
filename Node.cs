using System.IO;
using System;
using System.Collections.Generic;

public abstract class Node{
    private List<Pin> input_pins;
    private List<Pin> output_pins;
    private List<Value> nodeValues;
    private string type;
    private int node_id;

    public static int id_count = 0;
    public abstract void run();
    public abstract T get();
    public Node(){
        node_id=id_count++;
    }
    public int getID(){
        return node_id;
    }
    public string getType(){
        return type;
    }
    public void setType(string _type){
        type=_type;
    }
    public void setNext(Node _next){
        next=_next;
    }
    public Node getNext(){
        return next;
    }
}