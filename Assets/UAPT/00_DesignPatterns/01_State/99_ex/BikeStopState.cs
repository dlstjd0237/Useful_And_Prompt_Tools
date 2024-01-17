using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UAPT.State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;
        public void Handle(BikeController controller)
        {
            bikeController = controller != null ? controller : null;
            controller.CurrentSpeed = 0;
            Debug.Log("∏ÿ√Ë¥Á");
        }

    }
}

