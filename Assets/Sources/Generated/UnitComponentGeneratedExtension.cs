using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public UnitComponent unit { get { return (UnitComponent)GetComponent(ComponentIds.Unit); } }

        public bool hasUnit { get { return HasComponent(ComponentIds.Unit); } }

        static readonly Stack<UnitComponent> _unitComponentPool = new Stack<UnitComponent>();

        public static void ClearUnitComponentPool() {
            _unitComponentPool.Clear();
        }

        public Entity AddUnit(string newName) {
            var component = _unitComponentPool.Count > 0 ? _unitComponentPool.Pop() : new UnitComponent();
            component.name = newName;
            return AddComponent(ComponentIds.Unit, component);
        }

        public Entity ReplaceUnit(string newName) {
            var previousComponent = hasUnit ? unit : null;
            var component = _unitComponentPool.Count > 0 ? _unitComponentPool.Pop() : new UnitComponent();
            component.name = newName;
            ReplaceComponent(ComponentIds.Unit, component);
            if (previousComponent != null) {
                _unitComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveUnit() {
            var component = unit;
            RemoveComponent(ComponentIds.Unit);
            _unitComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherUnit;

        public static IMatcher Unit {
            get {
                if (_matcherUnit == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Unit);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherUnit = matcher;
                }

                return _matcherUnit;
            }
        }
    }
}
