namespace Battleship.Core;

public class Ship
{
    private readonly HashSet<Position> _cells;
    private readonly HashSet<Position> _hits = new();

    public IReadOnlyCollection<Position> Cells => _cells;
    public IReadOnlyCollection<Position> Hits => _hits;


    public Ship(IEnumerable<Position> cells)
    {
        _cells = cells.ToHashSet();

        if (_cells.Count == 0)
        {
            throw new ArgumentException("Ship must have at least one cell.", nameof(cells));
        }
    }

    public bool IsSunk()
    {
        return _hits.Count == _cells.Count;
    }

    public bool Occupies(Position position)
    {
        return _cells.Contains(position);
    }

    public bool RegisterHit(Position position)
    {
        if (!_cells.Contains(position))
        {
            return false;
        }

        _hits.Add(position);
        return true;
    }
}
