using System;
using System.Collections.Generic;
public abstract class Node{
    private List<Pin> input_pins;
    private List<Pin> output_pins;
    private Node next;
    private string type;
    public abstract void run();
    public string getType(){
        return type;
    }
    public void setType(string t){
        type=t;
    }
    public void setNext(Node n){
        next=n;
    }
    public Node getNext(){
        return next;
    }
}