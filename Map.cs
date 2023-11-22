using Godot;
using static Godot.GD;

public partial class Map : TileMap
{

    [Export]
    public Vector2 MapSize { get; set; }
    public override void _Ready()
    {
        base._Ready();
        GenerateMap();
    }

    private void GenerateMap()
    {
        Print($"MapSize X:{MapSize.X} Y:{MapSize.Y}");

        // Obtener mitad del mapa
        var minXCoords = (MapSize.X / 2) * -1;
        var minYCoords = (MapSize.Y / 2) * -1;
        var maxXCoords = (MapSize.X / 2);
        var maxYCoords = (MapSize.Y / 2);

        var xCoords = new Vector2I((int)minXCoords, (int)maxXCoords);
        var yCoords = new Vector2I((int)minYCoords, (int)maxYCoords);


        for (int y = (int)minYCoords; y < (int)maxYCoords; y++)
        {
            for (int x = (int)minXCoords; x < (int)maxXCoords; x++)
            {
                var rng = new RandomNumberGenerator();
                var rngI = rng.RandiRange(0, 100);

                if (rngI <= 33)
                {
                    var rngTile = rng.RandiRange(0, 3);
                    this.SetCell(0, new Vector2I(x, y), 1, new Vector2I(rngTile, 0), 0);
                }
                else
                {
                    this.SetCell(0, new Vector2I(x, y), 0, new Vector2I(0, 0), 0);
                }

            }
        }
    }

}
