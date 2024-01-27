using UnityEngine;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Inputs
{
    public class InputService : ITickable  
    {
        public Vector3 InputVector { get; private set; }

        public void Tick()
        {
            InputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
    }
}