namespace Tiles {
    public abstract class Tile {
        public int _level { get; }
        public int _position_x { get; }
        public int _position_y { get; }
        public string name { get; }

        protected Tile(int positionX, int positionY, string name) {
            _level = 1;
            _position_x = positionX;
            _position_y = positionY;
        }
    }
}