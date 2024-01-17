using System.Collections;//엄준식은 살아있다.
using System.Collections.Generic;
using UnityEngine;
using System;
namespace UAPT.State
{
    public enum Direction
    {
        Left,
        Right
    }

    public class BikeController : MonoBehaviour
    {
        public float MaxSpeed = 2.0f;

        public float TrunDistance = 2.0f;

        public float CurrentSpeed = 0.0f;

        public Direction CurrentTurnDir;

        //상태값 제어
        private IBikeState _startState, _stopState, _turnState;

        private BikeStateContext _bikeStateContext;


        private void Start()
        {
            _bikeStateContext = new BikeStateContext(this);

            _stopState = gameObject.AddComponent<BikeStopState>();
            _startState = gameObject.AddComponent<BikeStartState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();

            _bikeStateContext.Transition(_stopState);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartBike();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                StopBike();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Turn(Direction.Left);
            }
        }

        public void StartBike()
        {
            _bikeStateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _bikeStateContext.Transition(_stopState);
        }

        public void Turn(Direction dir)
        {
            CurrentTurnDir = dir;
            _bikeStateContext.Transition(_turnState);
        }
    }

}

