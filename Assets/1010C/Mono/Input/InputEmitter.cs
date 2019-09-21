using UnityEngine;

namespace _1010C.Mono.Input
{
    public class InputEmitter : MonoBehaviour
    {
        private Contexts _contexts;

        private UnityEngine.Camera _cam;

        // Start is called before the first frame update
        private void Start()
        {
            _cam = UnityEngine.Camera.main;
            _contexts = Contexts.sharedInstance;
        }

        // Update is called once per frame
        private void Update()
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