//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _1010C.Components.Tile.TileComponent tileComponent = new _1010C.Components.Tile.TileComponent();

    public bool isTile {
        get { return HasComponent(GameComponentsLookup.Tile); }
        set {
            if (value != isTile) {
                var index = GameComponentsLookup.Tile;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : tileComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherTile;

    public static Entitas.IMatcher<GameEntity> Tile {
        get {
            if (_matcherTile == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Tile);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTile = matcher;
            }

            return _matcherTile;
        }
    }
}
