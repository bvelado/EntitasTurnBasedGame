namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateUnitsSystem() {
            return this.CreateSystem<CreateUnitsSystem>();
        }
    }
}