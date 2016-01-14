namespace Entitas {
    public partial class Entity {
        static readonly StartTurnComponent startTurnComponent = new StartTurnComponent();

        public bool isStartTurn {
            get { return HasComponent(ComponentIds.StartTurn); }
            set {
                if (value != isStartTurn) {
                    if (value) {
                        AddComponent(ComponentIds.StartTurn, startTurnComponent);
                    } else {
                        RemoveComponent(ComponentIds.StartTurn);
                    }
                }
            }
        }

        public Entity IsStartTurn(bool value) {
            isStartTurn = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherStartTurn;

        public static IMatcher StartTurn {
            get {
                if (_matcherStartTurn == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.StartTurn);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherStartTurn = matcher;
                }

                return _matcherStartTurn;
            }
        }
    }
}
