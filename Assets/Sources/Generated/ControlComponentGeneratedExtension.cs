namespace Entitas {
    public partial class Entity {
        static readonly ControlComponent controlComponent = new ControlComponent();

        public bool isControl {
            get { return HasComponent(ComponentIds.Control); }
            set {
                if (value != isControl) {
                    if (value) {
                        AddComponent(ComponentIds.Control, controlComponent);
                    } else {
                        RemoveComponent(ComponentIds.Control);
                    }
                }
            }
        }

        public Entity IsControl(bool value) {
            isControl = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherControl;

        public static IMatcher Control {
            get {
                if (_matcherControl == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Control);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherControl = matcher;
                }

                return _matcherControl;
            }
        }
    }
}
