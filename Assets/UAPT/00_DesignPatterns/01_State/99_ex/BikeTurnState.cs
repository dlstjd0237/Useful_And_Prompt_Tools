using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UAPT.State
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private Vector3 _turnDir;
        private BikeController _bikeController;
        public void Handle(BikeController controller)
        {
            if (!_bikeController)
            {
                _bikeController = controller;
            }
            _turnDir.x = (float)_bikeController.TrunDistance;
            if (_bikeController.CurrentSpeed > 0)
            {
                transform.Translate(_turnDir * 2);
            }
            Debug.Log("È¸ÀüÇß´å");


            transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0), 30);

        }



    }
}

