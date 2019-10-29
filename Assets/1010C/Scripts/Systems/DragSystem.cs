using Entitas;

namespace _1010C.Scripts.Systems
{
    public class DragSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _dragGroup;

        public DragSystem(Contexts contexts)
        {
            _contexts = contexts;
            _dragGroup =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Piece, GameMatcher.Drag, GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var piece in _dragGroup)
            {
                var touchPos = _contexts.input.GetGroup(InputMatcher.TouchPosition).GetSingleEntity().touchPosition;
                piece.ReplacePosition(touchPos.Value);
            }
        }
    }
}