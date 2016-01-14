namespace Entitas {
    public partial class Pool {
        public ISystem CreateTurnManagerSystem() {
            return this.CreateSystem<TurnManagerSystem>();
        }
    }
}