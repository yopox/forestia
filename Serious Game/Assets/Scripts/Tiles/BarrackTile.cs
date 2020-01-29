namespace Tiles{
    public abstract class BarrackTile : BuildingTile{
        
        private const string BarrackTileName = "Barrack";
        protected BarrackTile(int positionX, int positionY) : base(positionX, positionY, BarrackTileName){
        }

        public void NewUnit(){
            // TODO
        }
    }
}