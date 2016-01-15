namespace Entitas {
    public partial class Pool {
        public ISystem CreateStartTurnSystem() {
            return this.CreateSystem<StartTurnSystem>();
        }
    }
}