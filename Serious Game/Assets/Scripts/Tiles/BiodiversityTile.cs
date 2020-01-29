namespace Tiles{
    public abstract class BiodiversityTile : Tile{
        
        // TODO bonus species
        
        protected BiodiversityTile(int positionX, int positionY, string name) : base(positionX, positionY, name){
        }

        public int GetBiodiversityScore(){
            return _level * 10;
        }
    }
}