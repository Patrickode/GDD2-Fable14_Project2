using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Astar
{
    // A* pathfinding algorithm as implemented here:
    // https://www.youtube.com/watch?v=HCt_CYOW9jg
    // (Modified slightly)
    public static Stack<Vertex> GetTilePath(Vector3Int[,] grid, Vector2Int start, Vector2Int end)
    {
        Vertex startVertex = null;
        Vertex endVertex = null;

        int width = grid.GetUpperBound(0) + 1;
        int height = grid.GetUpperBound(1) + 1;
        Vertex[,] vertices = new Vertex[width, height];

        // Create vertices
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, i].z == 0)
                    vertices[j, i] = new Vertex(grid[j, i].x, grid[j, i].y, true);
                else
                    vertices[j, i] = new Vertex(grid[j, i].x, grid[j, i].y, false);
            }
        }

        // Set up vertices
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                // Set all vertices' neighbours
                vertices[j, i].AddNeighbours(vertices, j, i);
                // If these are the coordinates desired for the start vertex
                if (vertices[j, i].x == start.x && vertices[j, i].y == start.y)
                {
                    // Set the start vertex pointer
                    startVertex = vertices[j, i];
                }
                // If these are the coordinates desired for the end vertex
                else if (vertices[j, i].x == end.x && vertices[j, i].y == end.y)
                {
                    // Set the end vertex pointer
                    endVertex = vertices[j, i];
                }

            }
        }

        // Exit early
        if (!IsValidPath(startVertex, endVertex))
        {
            return null;
        }

        // A* Algorithm
        List<Vertex> openSet = new List<Vertex>();
        List<Vertex> closedSet = new List<Vertex>();

        openSet.Add(startVertex);

        while (openSet.Count > 0)
        {
            // Find shortest step distance in the direction of your goal within the open set
            int indexOfShortest = 0;                    // Index of shortest distance vertex in the open set
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].walkable)
                {
                    if (openSet[i].f < openSet[indexOfShortest].f)
                        indexOfShortest = i;
                    // Tie!
                    else if (openSet[i].f == openSet[indexOfShortest].f)
                    {
                        // Tiebreaker is shortest h distance
                        if (openSet[i].h < openSet[indexOfShortest].h)
                            indexOfShortest = i;
                    }
                }
                
            }

            // Update current vertex
            Vertex current = openSet[indexOfShortest];

            // Found the end!
            // Returns the path
            if (current == endVertex)
            {
                Stack<Vertex> path = new Stack<Vertex>();
                path.Push(current);
                // Follow the path back to the start
                while (path.Peek().previousNeighbour != null)
                {
                    path.Push(path.Peek().previousNeighbour);
                }

                // Filter out the end and start vertices
                path = new Stack<Vertex>(path.Where(vertex => vertex != startVertex && vertex != endVertex).Reverse());

                return path;
            }

            openSet.Remove(current);
            closedSet.Add(current);

            // Finds the next closest step on the grid
            List<Vertex> neighbors = current.neighbours;
            // Loop through current vertex's (the one with the shortest f distance in openset) neighbors
            for (int i = 0; i < neighbors.Count; i++)
            {
                Vertex n = neighbors[i];

                // Check that the neighboor of our current tile is not within closed set and that it can be walked on
                if (!closedSet.Contains(n) && n.walkable)
                {
                    // Temporary comparison integer for seeing if a route is shorter than our current path
                    int tempG = current.g + 1;

                    bool newPath = false;
                    // Check that the neighboor we are checking is within the openset
                    if (openSet.Contains(n))
                    {
                        // The distance to the end goal from this neighboor is shorter so we need a new path
                        if (tempG < n.g)
                        {
                            n.g = tempG;
                            newPath = true;
                        }
                    }
                    // If its not in openSet or closed set, then it IS a new path and we should add it too openset
                    else
                    {
                        n.g = tempG;
                        newPath = true;
                        openSet.Add(n);
                    }
                    // If it is a newPath caclulate the H and F and set current to the neighboors previous
                    if (newPath)
                    {
                        n.h = Heuristic(n, endVertex);
                        n.f = n.g + n.h;
                        n.previousNeighbour = current;
                    }
                }
            }
        }

        // No path found
        return null;
    }

    private static bool IsValidPath(Vertex start, Vertex end)
    {
        if (end == null)
            return false;
        if (start == null)
            return false;
        if (!end.walkable)
            return false;

        return true;
    }

    // Returns distance (manhattan) from current Vertex to goal Vertex
    private static int Heuristic(Vertex current, Vertex goal)
    {
        return Math.Abs(goal.x - current.x) + Math.Abs(goal.y - current.y);
    }
}