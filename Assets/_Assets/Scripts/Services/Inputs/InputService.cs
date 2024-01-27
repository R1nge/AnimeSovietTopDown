using UnityEngine;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Inputs
{
    public class InputService  
    {
        public Vector3 InputVector { get; private set; }

        public void SetInputVector(Vector3 inputVector)
        {
            InputVector = inputVector;
        }
    }
}