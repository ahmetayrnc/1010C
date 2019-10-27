//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _1010C.Scripts.Components.Piece.ReturningToReserveComponent returningToReserveComponent = new _1010C.Scripts.Components.Piece.ReturningToReserveComponent();

    public bool isReturningToReserve {
        get { return HasComponent(GameComponentsLookup.ReturningToReserve); }
        set {
            if (value != isReturningToReserve) {
                var index = GameComponentsLookup.ReturningToReserve;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : returningToReserveComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReturningToReserve;

    public static Entitas.IMatcher<GameEntity> ReturningToReserve {
        get {
            if (_matcherReturningToReserve == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReturningToReserve);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReturningToReserve = matcher;
            }

            return _matcherReturningToReserve;
        }
    }
}