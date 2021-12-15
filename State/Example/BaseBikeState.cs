using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Patterns.Examples
{
    public class BaseBikeState : MonoBehaviour, IState
    {
        protected BikeController controller;

        public virtual void SetState(StateControllerBase newController)
        {
            if (!this.controller)
            {
                if (newController is BikeController)
                    this.controller = newController as BikeController;
            }            
        }
    }
}