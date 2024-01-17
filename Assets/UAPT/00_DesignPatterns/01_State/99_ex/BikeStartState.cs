using UnityEngine;

namespace UAPT.State
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController controller;
        public void Handle(BikeController controller)
        {
            this.controller = controller != null ? controller : null;
            controller.CurrentSpeed = controller.MaxSpeed;
            Debug.Log("움직였당");


        }

        private void Update()
        {
            if (controller)
            {
                if (controller.CurrentSpeed > 0)
                {
                    controller.transform.Translate(Vector3.forward);
                }
            }
        }
    }
}

