using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UAPT.State
{
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(ClientState))]
    public class ClientStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ClientState clientState = (ClientState)target;
            if (GUILayout.Button("스타트"))
            {
                clientState._bikeController.StartBike();
            }
            if (GUILayout.Button("회전"))
            {
                clientState._bikeController.Turn(Direction.Left);
            }
            if (GUILayout.Button("스탑"))
            {
                clientState._bikeController.StopBike();
            }
            base.OnInspectorGUI();
        }
    }
#endif
    public class ClientState : MonoBehaviour
    {
        [HideInInspector]
        public BikeController _bikeController;

        private void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
        }
        void OnGUI()
        {
            if (GUILayout.Button("Start Bike"))
                _bikeController.StartBike();

            if (GUILayout.Button("Turn Left"))
                _bikeController.Turn(Direction.Left);

            if (GUILayout.Button("Turn Right"))
                _bikeController.Turn(Direction.Right);

            if (GUILayout.Button("Stop Bike"))
                _bikeController.StopBike();
        }
    }

}

