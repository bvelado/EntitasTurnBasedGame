namespace Entitas {
    public partial class Entity {
        static readonly ControlableComponent controlableComponent = new ControlableComponent();

        public bool isControlable {
            get { return HasComponent(ComponentIds.Controlable); }
            set {
                if (value != isControlable) {
                    if (value) {
                        AddComponent(ComponentIds.Controlable, controlableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Controlable);
                    }
                }
            }
        }

        public Entity IsControlable(bool value) {
            isControlable = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity controlableEntity { get { return GetGroup(Matcher.Controlable).GetSingleEntity(); } }

        public bool isControlable {
            get { return controlableEntity != null; }
            set {
                var entity = controlableEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isControlable = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static IMatcher _matcherControlable;

        public static IMatcher Controlable {
            get {
                if (_matcherControlable == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Controlable);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherControlable = matcher;
                }

                return _matcherControlable;
            }
        }
    }
}
