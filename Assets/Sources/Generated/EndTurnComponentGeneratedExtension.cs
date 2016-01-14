namespace Entitas {
    public partial class Entity {
        static readonly EndTurnComponent endTurnComponent = new EndTurnComponent();

        public bool isEndTurn {
            get { return HasComponent(ComponentIds.EndTurn); }
            set {
                if (value != isEndTurn) {
                    if (value) {
                        AddComponent(ComponentIds.EndTurn, endTurnComponent);
                    } else {
                        RemoveComponent(ComponentIds.EndTurn);
                    }
                }
            }
        }

        public Entity IsEndTurn(bool value) {
            isEndTurn = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherEndTurn;

        public static IMatcher EndTurn {
            get {
                if (_matcherEndTurn == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.EndTurn);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherEndTurn = matcher;
                }

                return _matcherEndTurn;
            }
        }
    }
}
