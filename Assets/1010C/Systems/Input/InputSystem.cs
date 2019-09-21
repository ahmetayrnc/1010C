using Entitas;
using UnityEngine;

namespace _1010C.Systems.Input
{
    public sealed class InputSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private Camera _cam;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _cam = Camera.main;
        }

        public void Execute()
        {
            EmitInput();
        }

        private void EmitInput()
        {
            var touchDown = UnityEngine.Input.GetMouseButtonDown(0);
            var touchUp = UnityEngine.Input.GetMouseButtonUp(0);

            if (!touchDown && !touchUp) return;

            var mouseWorldPos = _cam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

            if (touchDown)
            {
                _contexts.input.CreateEntity().AddTouchDown(mouseWorldPos);
            }

            if (touchUp)
            {
                _contexts.input.CreateEntity().AddTouchUp(mouseWorldPos);
            }
        }
    }
}