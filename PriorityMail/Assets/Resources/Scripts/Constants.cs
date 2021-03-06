﻿using System.Collections.Generic;
using UnityEngine;

public enum Facet
{
    North = 0,
    West = 1,
    South = 2,
    East = 3,
    Up = 4,
    Down = 5,
    Unknown = 6
}

public enum Direction
{
    West = 1,
    East = -1,
    Up = 1,
    Down = -1,
    North = 1,
    South = -1
}

public enum Shade
{
    Nothing,
    Color1,
    Color2,
    Color3,
    Color4,
    Color5,
    Color6,
    Color7,
    Color8,
    Color9,
    Color10
}

public enum TileElementNames
{
    Vine,
    Bramble,
    Sigil,
    Ground,
    Rock,
    Boulder
}

public enum EditorTEIndices
{
    Pos1,
    Pos2,
    Direction
}

public enum CardinalDirection
{
    North,
    West,
    South,
    East
}

public enum DecalID
{
    FourStepPath = 10
}

public delegate TileElement TileElementConstructor(params object[] vars);

public class Constants
{

    public static readonly TileElement[] TILE_MODELS = new TileElement[] {
        new Vine(),
        new Bramble(),
        new Sigil(),
        new Ground(),
        new Rock(),
        new Boulder()
    };

    public static Facet VectorToFacet(Vector3Int vec)
    {
        if (vec.x == 1 && vec.y == 0 && vec.z == 0) { return Facet.North; }
        if (vec.x == -1 && vec.y == 0 && vec.z == 0) { return Facet.South; }
        if (vec.x == 0 && vec.y == 1 && vec.z == 0) { return Facet.Up; }
        if (vec.x == 0 && vec.y == -1 && vec.z == 0) { return Facet.Down; }
        if (vec.x == 0 && vec.y == 0 && vec.z == 1) { return Facet.West; }
        if (vec.x == 0 && vec.y == 0 && vec.z == -1) { return Facet.East; }
        return Facet.Unknown;
    }

    public static Vector3Int FacetToVector(Facet facet)
    {
        Vector3Int[] ftva = new Vector3Int[]
        {
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, 0, 1),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, 0, -1),
            new Vector3Int(0, 1, 0),
            new Vector3Int(0, -1, 0)
        };
        return ftva[(int)facet];
    }

    public static Facet FacetToModel(Facet facet)
    {
        return new Facet[]
        {
            Facet.Up,
            Facet.South,
            Facet.Down,
            Facet.East,
            Facet.North,
            Facet.West,
        }[(int)facet];
    }

    public static Facet FlipDirection(Facet facet)
    {
        return new Facet[]
        {
            Facet.South,
            Facet.East,
            Facet.North,
            Facet.West,
            Facet.Down,
            Facet.Up
        }[(int)facet];
    }

    public static readonly Vector3[] VINE_STRETCHES = new Vector3[]
    {
        new Vector3(1, 0.8f, 0.8f),
        new Vector3(0.8f, 0.8f, 1),
        new Vector3(1, 0.8f, 0.8f),
        new Vector3(0.8f, 0.8f, 1),
        new Vector3(0.8f, 1, 0.8f),
        new Vector3(0.8f, 1, 0.8f)
    };

    public static readonly Vector3[] VINE_ANCHORS = new Vector3[]
    {
        new Vector3(0.1f, 0.1f, 0),
        new Vector3(0, 0.1f, 0.1f),
        new Vector3(-0.1f, 0.1f, 0),
        new Vector3(0, 0.1f, -0.1f),
        new Vector3(0, 0, 0),
        new Vector3(0, 0, 0)
    };

    public static readonly Vector3[] VINE_STARTS = new Vector3[]
    {
        new Vector3(0.5f, 0.1f, 0),
        new Vector3(0, 0.1f, 0.5f),
        new Vector3(-0.5f, 0.1f, 0),
        new Vector3(0, 0.1f, -0.5f),
        new Vector3(0, -0.5f, 0),
        new Vector3(0, -0.5f, 0)
    };

    public static int DirectionToDegree (Facet direction)
    {
        return new int[]
        {
            90,
            0,
            270,
            180,
        }[(int)direction];
    }

    public static readonly string[] BASE_DECALS = new string[]
    {
        
    };

    public static readonly string[] DARK_DECALS = new string[]
    {
        "FourStepPath"
    };

    public static readonly string[] LIGHT_DECALS = new string[]
    {
        
    };
}
