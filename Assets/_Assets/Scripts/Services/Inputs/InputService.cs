using UnityEngine;

namespace _Assets.Scripts.Services.Inputs
{
    public class InputService  
    {
        public Vector3 InputVector { get; private set; }

        public void SetMovementVector(Vector3 inputVector) => InputVector = inputVector;
    }
}