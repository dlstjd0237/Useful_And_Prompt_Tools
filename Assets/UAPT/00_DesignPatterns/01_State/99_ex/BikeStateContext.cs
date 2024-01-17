using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UAPT.State
{

    public class BikeStateContext
    {
        public IBikeState CurretnState { get; set; }

        private readonly BikeController _bikeController;

        public BikeStateContext(BikeController bikeController)
        {
            _bikeController = bikeController;
        }

        public void Transition()
        {
            CurretnState.Handle(_bikeController);
        }

        public void Transition(IBikeState state)
        {
            CurretnState = state;
            CurretnState.Handle(_bikeController);
        }
        
    }
}

