using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public InputComponent input { get { return (InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        static readonly Stack<InputComponent> _inputComponentPool = new Stack<InputComponent>();

        public static void ClearInputComponentPool() {
            _inputComponentPool.Clear();
        }

        public Entity AddInput(InputIntent newIntent) {
            var component = _inputComponentPool.Count > 0 ? _inputComponentPool.Pop() : new InputComponent();
            component.intent = newIntent;
            return AddComponent(ComponentIds.Input, component);
        }

        public Entity ReplaceInput(InputIntent newIntent) {
            var previousComponent = hasInput ? input : null;
            var component = _inputComponentPool.Count > 0 ? _inputComponentPool.Pop() : new InputComponent();
            component.intent = newIntent;
            ReplaceComponent(ComponentIds.Input, component);
            if (previousComponent != null) {
                _inputComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveInput() {
            var component = input;
            RemoveComponent(ComponentIds.Input);
            _inputComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity inputEntity { get { return GetGroup(Matcher.Input).GetSingleEntity(); } }

        public InputComponent input { get { return inputEntity.input; } }

        public bool hasInput { get { return inputEntity != null; } }

        public Entity SetInput(InputIntent newIntent) {
            if (hasInput) {
                throw new EntitasException("Could not set input!\n" + this + " already has an entity with InputComponent!",
                    "You should check if the pool already has a inputEntity before setting it or use pool.ReplaceInput().");
            }
            var entity = CreateEntity();
            entity.AddInput(newIntent);
            return entity;
        }

        public Entity ReplaceInput(InputIntent newIntent) {
            var entity = inputEntity;
            if (entity == null) {
                entity = SetInput(newIntent);
            } else {
                entity.ReplaceInput(newIntent);
            }

            return entity;
        }

        public void RemoveInput() {
            DestroyEntity(inputEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInput;

        public static IMatcher Input {
            get {
                if (_matcherInput == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Input);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherInput = matcher;
                }

                return _matcherInput;
            }
        }
    }
}
