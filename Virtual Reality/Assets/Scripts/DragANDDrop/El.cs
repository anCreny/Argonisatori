using UnityEngine;

namespace DragANDDrop
{
    public interface El
    {
        public void SetOutput(El element);

        public void TakeColor(Color color);

        public void Interrupt();
    }
}