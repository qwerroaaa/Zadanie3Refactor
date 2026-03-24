namespace Battleship.Core;

public class Game
{
    public Board Board {get; }

    private readonly Dictionary<Position, string> _shotHistory = new();
    public IReadOnlyDictionary<Position, string> ShotHistory => _shotHistory;

    public Game(Board board)
    {
        Board = board ?? throw new ArgumentNullException(nameof(board));
    }

    public string MakeShot(Position position)
    {
        var result = Board.Fire(position);
        _shotHistory[position] = result;
        return result;
    }
}
