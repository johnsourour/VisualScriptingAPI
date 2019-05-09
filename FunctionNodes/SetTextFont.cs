using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFont : Node {

    public SetTextFont() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Text   
        addInputPin(new PinValue()); //string - font
        addInputPin(new PinValue()); //vector - color 
        addInputPin(new PinValue()); //string - fontstyle
        addInputPin(new PinValue()); //string - Alignment
        addInputPin(new PinValue()); //int - size
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        for(int i=0;i<6;i++)if(!inputPins[i].exists())return false;
        return true;
    }
    
    public override void run(){

        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

             
        
        string text_font = inputPins[1].get();
        int sze = inputPins[5].get();
        Vector3 v = inputPins[2].get();       
        string text_style = inputPins[3].get();       
        string text_align = inputPins[4].get();  

        TextMesh textComponent = inputPins[0].get();   
        Font fnt = Font.CreateDynamicFontFromOSFont(text_font, sze);
        Color color = new Color(v.x, v.y, v.z, 1);

        textComponent.font = fnt;
        textComponent.fontSize = sze;
        textComponent.fontStyle = getStyle(text_style);
        textComponent.color = color;
        textComponent.alignment = getAlign(text_align);
        
        Debug.Log("Text Font Properties Set");

        outputPins[0].run();
    }
    private FontStyle getStyle(string s){
        switch(s){
            case "Normal":
                return FontStyle.Normal;
            case "Bold":
                return FontStyle.Bold;
            case "Italic":
                return FontStyle.Italic;
            case "BoldAndItalic":
                return FontStyle.BoldAndItalic;
            default:{
                Debug.LogError("Invalid font style");
                return FontStyle.Normal;
            }
        }
    }
    private TextAlignment getAlign(string s){
        switch(s){
            case "Left":
                return TextAlignment.Left;
            case "Right":
                return TextAlignment.Right;
            case "Center":
                return TextAlignment.Center;
            default:{
                Debug.LogError("Invalid text alignment");
                return TextAlignment.Center;
            }
        }
    }
}