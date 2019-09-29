using Entitas;

namespace _1010C.Scripts.Systems.Input
{
    public class CleanupInputSystem : ICleanupSystem
    {
        private readonly IGroup<InputEntity> _touchDownGroup;
        private readonly IGroup<InputEntity> _touchUpGroup;
        private readonly IGroup<InputEntity> _touchPositionGroup;

        public CleanupInputSystem(Contexts contexts)
        {
            _touchDownGroup = contexts.input.GetGroup(InputMatcher.TouchDown);
            _touchUpGroup = contexts.input.GetGroup(InputMatcher.TouchUp);
            _touchPositionGroup = contexts.input.GetGroup(InputMatcher.TouchPosition);
        }

        public void Cleanup()
        {
            foreach (var touchDown in _touchDownGroup.GetEntities())
            {
                touchDown.Destroy();
            }

            foreach (var touchUp in _touchUpGroup.GetEntities())
            {
                touchUp.Destroy();
            }

            foreach (var touchPosition in _touchPositionGroup.GetEntities())
            {
                touchPosition.Destroy();
            }
        }
    }
}