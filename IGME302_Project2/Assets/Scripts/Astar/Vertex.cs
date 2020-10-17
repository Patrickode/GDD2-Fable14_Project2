using System.Collections.Generic;
using UnityEngine;

public class Vertex
{
    public int x;
    public int y;
    public bool walkable;
    
    public int f;                               // Total calculation of distance and priority. g + h
    public int g;                               // Distance from start to current node
    public int h;                               // Heuristics calculation of distance from current node to target Max(d(x), d(y)) (diagonal)

    public List<Vertex> neighbours;
    public Vertex previousNeighbour;     // Fastest previous neighbour to this node

    public Vertex(int x, int y, bool walkable)
    {
        this.x = x;
        this.y = y;
        this.walkable = walkable;
        f = 0;
        g = 0;
        h = 0;

        neighbours = new List<Vertex>();
        previousNeighbour = null;
    }

    public void AddNeighbours(Vertex[,] grid, int x, int y)
    {
        // Right
        if (x < grid.GetUpperBound(0))
            neighbours.Add(grid[x + 1, y]);
        // Left
        if (x > 0)
            neighbours.Add(grid[x - 1, y]);
        // Down
        if (y < grid.GetUpperBound(1))
            neighbours.Add(grid[x, y + 1]);
        // Up
        if (y > 0)
            neighbours.Add(grid[x, y - 1]);
    }
}
