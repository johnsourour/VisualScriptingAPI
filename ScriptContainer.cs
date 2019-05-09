using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class ScriptContainer : MonoBehaviour {
    SymbolTable symbolTable;
    
    public List<Node> nodes;

    EventNode eventStartNode;
    EventNode eventUpdateNode;
    EventNode eventPressNode;
    EventNode eventReleaseNode;
    EventNode eventSwipeUpNode;
    EventNode eventSwipeDownNode;
    EventNode eventSwipeLeftNode;
    EventNode eventSwipeRightNode;

    public Transform contentArea;

    public ScriptContainer() {
        symbolTable = new SymbolTable();
        nodes = new List<Node>();
    }

    public void ScriptStart() {
        if (eventStartNode!=null)
            eventStartNode.run();
    }

    public void Update() {
        if (eventUpdateNode!=null)
            eventUpdateNode.run();

        if (Input.GetMouseButtonDown(0) && eventPressNode!=null)
            eventPressNode.run();

        if (Input.GetMouseButtonUp(0) && eventReleaseNode!=null)
            eventReleaseNode.run();

        if (Input.GetKeyDown(KeyCode.UpArrow) && eventSwipeUpNode!=null)
            eventSwipeUpNode.run();

        if (Input.GetKeyDown(KeyCode.DownArrow) && eventSwipeDownNode!=null)
            eventSwipeDownNode.run();
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && eventSwipeLeftNode!=null)
            eventSwipeLeftNode.run();

        if (Input.GetKeyDown(KeyCode.RightArrow) && eventSwipeRightNode!=null)
            eventSwipeRightNode.run();
    }
    
    public Node createNode(string type){
        switch(type)
        {
            case "rotateobject":
                return new RotateObject();
            case "scaleobject":
                return new ScaleObject();
            case "moveobject":
                return new MoveObject();
            case "printstring":
                return new PrintStringNode();
            case "createobject":
                return new CreateObject();
            case "createtext":
                return new CreateTextComponent();
            case "create3d":
                return new Create3DComponent();
            case "loadfile":
                return new FileToString();
            case "writefile":
                return new WriteToFile();
            case "gettext":
                return new GetTextComponent();
            case "get3d":
                return new Get3DComponent();
            case "setcomptext":
                return new SetComponentText();
            case "setfontsize":
                return new SetTextFont();
            case "getcomptext":
                return new GetComponentText();
            case "makevector":
                return new MakeVector();
            case "breakvector":
                return new BreakVector();
            case "numtoint":
                return new NumberToInt();
            case "inttonum":
                return new IntToNumber();
            case "numtostring":
                return new NumberToString();
            case "inttostring":
                return new IntToString();
            case "addint":
                return new AddInt();
            case "addnum":
                return new AddNumber();
            case "subint":
                return new SubInt();
            case "subnum":
                return new SubNumber();
            case "divint":
                return new DivInt();
            case "divnum":
                return new DivNumber();
            case "multint":
                return new MultInt();
            case "multnum":
                return new MultNumber();
            case "sqrt":
                return new SquareRoot();
            case "gettime":
                return new GetTime();
            case "lerpnum":
                return new LerpNumber();
            case "lerpvector":
                return new LerpVector();
            case "gtenum":
                return new GreaterEqualNumber();
            case "gtnum":
                return new GreaterNumber();
            case "gteint":
                return new GreaterEqualInt();
            case "gtint":
                return new GreaterInt();
            case "equalnum":
                return new EqualNumber();
            case "equalint":
                return new EqualInt();
            case "not":
                return new Not();
            case "concat":
                return new ConcatenateString();
            case "substring":
                return new GetSubstring();
            case "stringindex":
                return new IndexString();
            case "strlen":
                return new StringLength();
            case "exit":
                return new ExitNode();
            case "setpmstatus":
                return new SetPMStatus();
            case "getgesturepos":
                return new GetGesturePosition();
            case "getimage":
                return new GetImageComponent();
            case "createimage":
                return new CreateImageComponent();
            case "setcompimage":
                return new SetComponentImage();
            case "instantiatemodel":
                return new InstantiateModel();
            
            case "eventstart":
                eventStartNode = new EventNode();
                return eventStartNode;
            case "eventupdate":
                eventUpdateNode = new EventNode();
                return eventUpdateNode;
            case "eventgesturepress":
                eventPressNode = new EventNode();
                return eventPressNode;
            case "eventgesturerelease":
                eventReleaseNode = new EventNode();
                return eventReleaseNode;
            case "eventgestureswipeup":
                eventSwipeUpNode = new EventNode();
                return eventSwipeUpNode;
            case "eventgestureswipedown":
                eventSwipeDownNode = new EventNode();
                return eventSwipeDownNode;
            case "eventgestureswiperight":
                eventSwipeRightNode = new EventNode();
                return eventSwipeRightNode;
            case "eventgestureswipeleft":
                eventSwipeLeftNode = new EventNode();
                return eventSwipeLeftNode;
        
            case "setterbool":
                return new SetterNode<bool>(symbolTable);
            case "setterstring":
                return new SetterNode<string>(symbolTable);
            case "setternum":
                return new SetterNode<float>(symbolTable);
            case "setterint":
                return new SetterNode<int>(symbolTable);
            case "setterobj":
                return new SetterNode<GameObject>(symbolTable);
            case "setter3d":
                return new SetterNode<_3DObject>(symbolTable);
            case "setterpm":
                return new SetterNode<GameObject>(symbolTable);
            case "settertext":
                return new SetterNode<TextMesh>(symbolTable);
            case "settervector":
                return new SetterNode<Vector3>(symbolTable);
        
            case "getterbool":
                return new GetterNode<bool>(symbolTable);
            case "getterstring":
                return new GetterNode<string>(symbolTable);
            case "getternum":
                return new GetterNode<float>(symbolTable);
            case "getterint":
                return new GetterNode<int>(symbolTable);
            case "getterobj":
                return new GetterNode<GameObject>(symbolTable);
            case "getter3d":
                return new GetterNode<_3DObject>(symbolTable);
            case "getterpm":
                return new GetterNode<GameObject>(symbolTable);
            case "gettertext":
                return new GetterNode<TextMesh>(symbolTable);
            case "gettervector":
                return new GetterNode<Vector3>(symbolTable);

        
            case "constantbool":
                return new ConstantNode<bool>();
            case "constantstring":
                return new ConstantNode<string>();
            case "constantnum":
                return new ConstantNode<float>();
            case "constantint":
                return new ConstantNode<int>();
            case "constantvector":
                return new ConstantNode<Vector3>();

                
            case "if":
                return new IfNode();
            case "while":
                return new WhileNode();
            
            default:
            {
                Debug.LogError("Invalid Node Internal Name: " + type);
                return new EventNode();
            }          
        }
    }
    public void ParseIntermediateCode(string filename)
    {
        bool var_flag = true;
        int list_count = 0;
        uint pinID = 0;
        
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

        using (StreamReader streamReader = new StreamReader(fs, Encoding.Default))
        {
            int lineno = 0;
            string line = String.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line == "[" && list_count == 0)
                {
                    var_flag = false;
                    list_count++;
                    line = streamReader.ReadLine();
                }

                if (var_flag)
                {
                    string[] tokens = line.Split(':');
                    if (tokens[0] != null && tokens[1] != null)
                    {
                        switch (tokens[0])
                        {
                            case "GameObject":
                                symbolTable.Add<GameObject>(tokens[1]);
                                break;
                            case "Component3D":
                                symbolTable.Add<_3DObject>(tokens[1]);
                                break;
                            case "Integer":
                                symbolTable.Add<int>(tokens[1]);
                                break;
                            case "Number":
                                symbolTable.Add<float>(tokens[1]);
                                break;
                            case "ProjectionMap":
                                symbolTable.Add<GameObject>(tokens[1]);
                                break;
                            case "String":
                                symbolTable.Add<string>(tokens[1]);
                                break;
                            case "Bool":
                                symbolTable.Add<bool>(tokens[1]);
                                break;
                            case "ComponentText":
                                symbolTable.Add<Text>(tokens[1]);
                                break;
                            case "Vector":
                                symbolTable.Add<Vector3>(tokens[1]);
                                break;
                            case "Image":
                               symbolTable.Add<Image>(tokens[1]);
                               break;
                            default:
                                Debug.LogError("Invalid type in Symbol Table Entry");
                                break;
                        }
                    }
                }
                else //if node_flag
                {
                    if (line == "{")
                    {
                        string internal_node_name = streamReader.ReadLine();
                        string displayname = streamReader.ReadLine();
                        dynamic nd = createNode(internal_node_name);
                        ((Node)nd).displayname = displayname;
                        ((Node)nd).internalname = internal_node_name;
                        ((Node)nd).scriptContainer = this;
                        nodes.Add(nd);

                        string node_type = streamReader.ReadLine();
                        NodeType nt = NodeType.Event;
                        switch (node_type)
                        {
                            case "Constant":
                                nt = NodeType.Constant;
                                break;
                            case "Event":
                                nt = NodeType.Event;
                                break;
                            case "FlowNode":
                                nt = NodeType.FlowNode;
                                break;
                            case "Function":
                                nt = NodeType.Function;
                                break;
                            case "Getter":
                                nt = NodeType.Getter;
                                break;
                            case "Setter":
                                nt = NodeType.Setter;
                                break;
                            case "Intermediate":
                                nt = NodeType.Intermediate;
                                break;
                            default:
                                Debug.LogError("Invalid Node Type " + node_type);
                                break;
                        }

                        while (streamReader.ReadLine() != "[") ; //ignore graphical data

                        line = streamReader.ReadLine();
                        pinID = 0;
                        while (line != "]") //read input pins
                        {
                            if (lineno++ >= 2000) {
                                Debug.Log(line);
                                Debug.Log("ERROR");
                                return;
                            }
                            int colonpos = line.IndexOf(":");
                            int bracketpos = line.IndexOf(" (");

                            // string pin_name = line.Substring(0, colonpos);
                            string pindt = line.Substring(colonpos + 1, bracketpos - colonpos - 1);
                            if (pindt != "Execution") //save pins if not execution
                            {
                                uint node_index, pin_index, datatype_index_start, datatype_index_end;
                                string datatype;

                                //parse line to find node and pin
                                int p  = (line.IndexOf("node", bracketpos) + 4);
                                int p2 = (line.IndexOf("pin", p));
                                int p3 = (line.IndexOf(")", p2));
                                node_index = Convert.ToUInt32(line.Substring(p, p2 - p - 2));
                                pin_index = Convert.ToUInt32(line.Substring(p2 + 3, p3 - p2 - 3));
                                
                                PinDataType pdt = PinDataType.Number; //Default

                                switch (pindt)
                                {
                                    case "GameObject":
                                        pdt = PinDataType.GameObject;
                                        break;
                                    case "Component3D":
                                        pdt = PinDataType.Component3D;
                                        break;
                                    case "Integer":
                                        pdt = PinDataType.Integer;
                                        break;
                                    case "Number":
                                        pdt = PinDataType.Number;
                                        break;
                                    case "ProjectionMap":
                                        pdt = PinDataType.ProjectionMap;
                                        break;
                                    case "String":
                                        pdt = PinDataType.String;
                                        break;
                                    case "Bool":
                                        pdt = PinDataType.Bool;
                                        break;
                                    case "ComponentText":
                                        pdt = PinDataType.ComponentText;
                                        break;
                                    case "Image":
                                       pdt = PinDataType.Image;
                                       break;
                                    case "VariableReference":
                                       pdt = PinDataType.VariableReference;
                                       break;
                                    case "Vector":
                                        pdt = PinDataType.Vector;
                                        break;
                                    default:
                                        Debug.LogError("Invalid Pin Datatype: " + pindt);
                                        break;
                                }

                                nd.setInputPin((int)pinID++, node_index, pin_index, pdt);
                            }
                            line = streamReader.ReadLine();
                        }

                        streamReader.ReadLine(); //ignore '['

                        line = streamReader.ReadLine();
                        pinID = 0;
                        while (line != "]") //read ouput pins
                        {
                            if (lineno++ >= 2000) {
                                Debug.Log(line);
                                Debug.Log("ERROR");
                                return;
                            }

                            int colonpos = line.IndexOf(":");
                            int bracketpos = line.IndexOf(" [");

                            string pindt = line.Substring(colonpos + 1, bracketpos - colonpos - 1);
                            if (pindt == "Execution") //save pins only if execution
                            {
                                uint node_index, pin_index;
                                
                                if (line.IndexOf("(") != -1) {

                                        //parse line to find node and pin
                                        int p  = (line.IndexOf("node") + 4);
                                        int p2 = (line.IndexOf("pin", p));
                                        int p3 = (line.IndexOf(")", p2));
                                        string nodeidstr = line.Substring(p, p2 - p - 2);
                                        string pinidstr = line.Substring(p2 + 3, p3 - p2 - 3);
                                        node_index = Convert.ToUInt32(nodeidstr);
                                        pin_index = Convert.ToUInt32(pinidstr);
                                    
                                    //parse line to find node and pin
                                    nd.setOutputPin((int)pinID++, node_index, pin_index);
                                }
                                
                            }
                            
                            line = streamReader.ReadLine();
                        }

                        streamReader.ReadLine(); //ignore '['

                        line = streamReader.ReadLine();
                        pinID = 0;
                        while (line != "]") //read parameters
                        {
                            if (lineno++ >= 2000) {
                                Debug.Log(line);
                                Debug.Log("ERROR");
                                return;
                            }

                            int p1 = line.IndexOf(":");
                            int p2 = line.IndexOf(":", p1 + 1);
                            string typename = line.Substring(p1 + 1, p2 - p1 - 1);
                            string value = line.Substring(p2 + 1);
                            switch (typename)
                            {
                                case "Integer": {
                                    int intval = Convert.ToInt32(value);
                                    ConstantNode<int> cn = (ConstantNode<int>)nd;
                                    cn.setConstant(intval);
                                    break;
                                }
                                case "Number": {
                                    float floatval = float.Parse(value);
                                    ConstantNode<float> cn = (ConstantNode<float>)nd;
                                    cn.setConstant(floatval);
                                    break;
                                }
                                case "String": {
                                    ConstantNode<string> cn = (ConstantNode<string>)nd;
                                    cn.setConstant(value);
                                    break;
                                }
                                case "Bool": {
                                    bool boolval = value == "on";
                                    ConstantNode<bool> cn = (ConstantNode<bool>)nd;
                                    cn.setConstant(boolval);
                                    break;
                                }
                                case "Vector": {
                                    int pc1 = value.IndexOf(",");
                                    int pc2 = value.LastIndexOf(",");
                                    string x = value.Substring(0, pc1);
                                    string y = value.Substring(pc1 + 1, pc2 - pc1 - 1);
                                    string z = value.Substring(pc2 + 1);
                                    float xf = float.Parse(x);
                                    float yf = float.Parse(y);
                                    float zf = float.Parse(z);
                                    ConstantNode<Vector3> cn = (ConstantNode<Vector3>)nd;
                                    cn.setConstant(new Vector3(xf, yf, zf));
                                    break;
                                }
                                case "VariableReference": {
                                    if (nt == NodeType.Getter) {
                                        GetterNode gn = (GetterNode)nd;
                                        gn.setVarName(value);
                                    }
                                    else if (nt == NodeType.Setter) {
                                        SetterNode sn = (SetterNode)nd;
                                        sn.setVarName(value);
                                    }
                                    else {
                                        Debug.Log("Unexpected setter!");
                                    }
                                    break;
                                }
                                default:
                                    Debug.LogError("Invalid Parameter Datatype");
                                    break;
                            }

                            line = streamReader.ReadLine();
                        }
                        streamReader.ReadLine(); //ignore "}"
                    }
                }
            }
        }
    

        foreach (Node n in nodes) {
            n.setPinValues();
        }
    }
}
