using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public TurnOrderComponent turnOrder { get { return (TurnOrderComponent)GetComponent(ComponentIds.TurnOrder); } }

        public bool hasTurnOrder { get { return HasComponent(ComponentIds.TurnOrder); } }

        static readonly Stack<TurnOrderComponent> _turnOrderComponentPool = new Stack<TurnOrderComponent>();

        public static void ClearTurnOrderComponentPool() {
            _turnOrderComponentPool.Clear();
        }

        public Entity AddTurnOrder(float newSpeed) {
            var component = _turnOrderComponentPool.Count > 0 ? _turnOrderComponentPool.Pop() : new TurnOrderComponent();
            component.speed = newSpeed;
            return AddComponent(ComponentIds.TurnOrder, component);
        }

        public Entity ReplaceTurnOrder(float newSpeed) {
            var previousComponent = hasTurnOrder ? turnOrder : null;
            var component = _turnOrderComponentPool.Count > 0 ? _turnOrderComponentPool.Pop() : new TurnOrderComponent();
            component.speed = newSpeed;
            ReplaceComponent(ComponentIds.TurnOrder, component);
            if (previousComponent != null) {
                _turnOrderComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTurnOrder() {
            var component = turnOrder;
            RemoveComponent(ComponentIds.TurnOrder);
            _turnOrderComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTurnOrder;

        public static IMatcher TurnOrder {
            get {
                if (_matcherTurnOrder == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TurnOrder);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTurnOrder = matcher;
                }

                return _matcherTurnOrder;
            }
        }
    }
}
