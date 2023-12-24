using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class DialogueContainer : ScriptableObject
{
    public List<NodeLinkData> nodeLinks = new List<NodeLinkData>();
    public List<DialogueNodeData> DialogueNodeData = new List<DialogueNodeData>();
}
