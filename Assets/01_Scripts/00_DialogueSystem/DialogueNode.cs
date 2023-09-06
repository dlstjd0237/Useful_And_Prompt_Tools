using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DialogueNode : Node
{
    public string GUID;//노드들을 구분하기 위한 아이디
    public string DialogueText; //대화 내용
    public bool EntryPoint = false; //진입점 
}
