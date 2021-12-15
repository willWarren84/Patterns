using System.Collections.Generic;
using UnityEngine;

namespace WW.Patterns
{
    public abstract class StateControllerBase: MonoBehaviour
    {       
        protected StateContextBase stateContext;        

        protected abstract void SetStates();        
        protected void Start()
        {
            stateContext = new StateContextBase(this);
            SetStates();
        }
    }
}