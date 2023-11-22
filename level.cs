using Godot;

public partial class level : Node
{
    [Export]
    RichTextLabel coords = new RichTextLabel();

    [Export]
    public TileMap Map { get; set; }

    public override void _Ready()
    {
        //coords = GetNode<RichTextLabel>("coordsText");

        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        var mouseCoords = this.GetViewport().GetMousePosition();
        GD.Print($"(X:{mouseCoords.X}, Y:{mouseCoords.Y})");
        //coords.Text = $"(X:{mouseCoords.X}, Y:{mouseCoords.Y})";
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
