namespace Entitas {
    public partial class Pool {
        public ISystem CreateEndTurnSystem() {
            return this.CreateSystem<EndTurnSystem>();
        }
    }
}