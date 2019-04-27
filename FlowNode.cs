using System.IO;
using System;
using System.Collections.Generic;


// FlowNode can act as both a WHILE Node and an IF/ELSE Node
public class FlowNode : Node {
    //input pins
    const int in_condition = 0; //should be Pin<boolean>
    const int in_exec = 1;

    //output pins
    const int out_true = 0; //acts as if for IF/ELSE and loop for WHILE
    const int out_false = 1; //acts as else for IF/ELSE and break for WHILE

    public FlowNode();
    public FlowNode(Pin<T> _in_condition, Pin<T> _in_exec, Pin<T> _out_true, Pin<T> _out_false)
    {
        input_pins = new List<Pin>();
        input_pins.Add(_in_condition);
        input_pins.Add(_in_exec);

        out_pins = new List<Pin>();
        out_pins.Add(_out_true);
        out_pins.Add(_out_false);
        
        base.setType("Flow");
    }
    public override void run(){
      
        var in = input_pins[in_exec];
        var condition = input_pins[in_condition].source.get() as boolean; //gets the value

        if (condition) {
            output_pins[out_true].source.run();
        }
        else{
            output_pins[out_false].source.run();
        }
        
    }
}