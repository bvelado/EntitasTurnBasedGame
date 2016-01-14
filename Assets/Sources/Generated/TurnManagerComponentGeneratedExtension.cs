namespace Entitas {
    public partial class Entity {
        static readonly TurnManagerComponent turnManagerComponent = new TurnManagerComponent();

        public bool isTurnManager {
            get { return HasComponent(ComponentIds.TurnManager); }
            set {
                if (value != isTurnManager) {
                    if (value) {
                        AddComponent(ComponentIds.TurnManager, turnManagerComponent);
                    } else {
                        RemoveComponent(ComponentIds.TurnManager);
                    }
                }
            }
        }

        public Entity IsTurnManager(bool value) {
            isTurnManager = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity turnManagerEntity { get { return GetGroup(Matcher.TurnManager).GetSingleEntity(); } }

        public bool isTurnManager {
            get { return turnManagerEntity != null; }
            set {
                var entity = turnManagerEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isTurnManager = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTurnManager;

        public static IMatcher TurnManager {
            get {
                if (_matcherTurnManager == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TurnManager);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTurnManager = matcher;
                }

                return _matcherTurnManager;
            }
        }
    }
}
