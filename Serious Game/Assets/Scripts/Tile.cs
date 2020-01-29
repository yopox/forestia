/// <summary>
/// Tile represents a tile of the grid.
/// </summary>
public class Tile {
    public enum Types {
        Forest,
        Land,
        Water,
        Road,
        Fire,
        Town
    }

    public Types Type { get; }

    public Tile(Types type) {
        Type = type;
    }

    /// <summary>
    /// Returns the biodiversity points of the tile.
    /// </summary>
    /// <returns></returns>
    public int ComputeBiodiversity() {
        return 1;
    }
}