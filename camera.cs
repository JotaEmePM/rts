using Godot;

public partial class camera : Camera2D
{
    [Export]
    public int CameraSpeed { get; set; } = 450;

    [Export]
    public int CameraMargin { get; set; } = 100;

    Vector2 CameraMovement;
    Vector2 PreviousMousePosition = new Vector2(0, 0);

    [Export]
    public TileMap Map { get; set; }


    public override void _Ready()
    {
        setCammeraLimit();

        base._Ready();
    }

    void setCammeraLimit()
    {
        var mapLimits = Map.GetUsedRect();
        var mapCellSize = Map.TileSet.TileSize;


        this.LimitLeft = mapLimits.Position.X * mapCellSize.X;
        this.LimitRight = mapLimits.End.X * mapCellSize.X;
        this.LimitTop = mapLimits.Position.Y * mapCellSize.Y;
        this.LimitBottom = mapLimits.End.Y * mapCellSize.Y;

    }

    public override void _PhysicsProcess(double delta)
    {
        var rec = this.GetViewport().GetVisibleRect();
        var v = GetLocalMousePosition() + rec.Size / 2;

        float movement = ((float)CameraSpeed * (float)delta);
        if (rec.Size.X - v.X <= CameraMargin)
        {
            CameraMovement.X += movement;
        }

        if (v.X <= CameraMargin)
        {
            CameraMovement.X -= movement;
        }

        if (rec.Size.Y - v.Y <= CameraMargin)
        {
            CameraMovement.Y += movement;
        }

        if (v.Y <= CameraMargin)
        {
            CameraMovement.Y -= movement;
        }

        this.Position = CameraMovement;
        //CameraMovement = Vector2.Zero;
        PreviousMousePosition = GetLocalMousePosition();

        base._PhysicsProcess(delta);
    }



}
