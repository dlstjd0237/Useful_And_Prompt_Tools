using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class GraphSaveUtility : MonoBehaviour
{
    private DialogueGraphView _targetGraphView;
    private DialogueContainer _containerCache;
    private List<Edge> Edges => _targetGraphView.edges.ToList();
    private List<DialogueNode> Nodes => _targetGraphView.nodes.ToList().Cast<DialogueNode>().ToList();
    public static GraphSaveUtility GetInstance(DialogueGraphView targetGraphView)
    {
        return new GraphSaveUtility
        {
            _targetGraphView = targetGraphView
        };
    }

    public void SaveGraph(string fileName)
    {
        if (!Edges.Any()) return; // 연결된 노드가 있는지 확인 연결되있지 않다면 저장 안됨

        var dialogueContainer = ScriptableObject.CreateInstance<DialogueContainer>();

        var connectedPorts = Edges.Where(x => x.input.node != null).ToArray();
        for (var i = 0; i < connectedPorts.Length; i++)
        {
            var outputNode = connectedPorts[i].output.node as DialogueNode;
            var inputNode = connectedPorts[i].input.node as DialogueNode;

            dialogueContainer.nodeLinks.Add(new NodeLinkData
            {
                BaseNodeGuid = outputNode.GUID,
                PortName = connectedPorts[i].output.portName,
                TargetNodeGuid = inputNode.GUID
            });
        }

        foreach (var dialogueNode in Nodes.Where(node => !node.EntryPoint))
        {
            dialogueContainer.DialogueNodeData.Add(new DialogueNodeData
            {
                Guid = dialogueNode.GUID,
                DialogueText = dialogueNode.DialogueText,
                Position = dialogueNode.GetPosition().position
            });
        }

        if (AssetDatabase.IsValidFolder("Assets/UAPT")) //Resources 폴더가 없음 만드셈
            AssetDatabase.CreateFolder("Assets/UAPT", "Resources");

        AssetDatabase.CreateAsset(dialogueContainer, $"Assets/UAPT/Resources/{fileName}.asset");
        AssetDatabase.SaveAssets();

    }
    public void LoadGraph(string fileName)
    {
        _containerCache = Resources.Load<DialogueContainer>(fileName);

        if (_containerCache == null)
        {
            EditorUtility.DisplayDialog("파일이 없습니다.", "해당 파일 이름의 데이터가 저장되어 있지 않습니다.", "ok");
            return;
        }

        ClearGraph();
        CreateNodes();
        ConnectNodes();
    }

    private void ConnectNodes()
    {
        throw new System.NotImplementedException();
    }

    private void CreateNodes()
    {
        throw new System.NotImplementedException();
    }

    private void ClearGraph()
    {
        throw new System.NotImplementedException();
    }
}
