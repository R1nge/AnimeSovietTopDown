using UnityEngine;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Inputs
{
    public class InputService : ITickable  
    {
        private Vector3 _input;
        public Vector3 InputVector => _input;
        public void Tick()
        {
            _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
    }
}