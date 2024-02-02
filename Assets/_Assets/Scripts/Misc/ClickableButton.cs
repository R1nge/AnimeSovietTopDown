using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Assets.Scripts.Misc
{
    public class ClickableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action ButtonDown;
        public event Action ButtonUp;
        
        public void OnPointerDown(PointerEventData eventData) => ButtonDown?.Invoke();

        public void OnPointerUp(PointerEventData eventData) => ButtonUp?.Invoke();
    }
}