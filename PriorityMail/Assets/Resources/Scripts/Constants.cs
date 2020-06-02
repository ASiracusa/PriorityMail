﻿using System.Collections.Generic;

public enum Facet
{
    Up = 0,
    Down = 1,
    North = 2,
    South = 3,
    West = 4,
    East = 5
}

public enum Shade
{
    Background = 0,
    Color1 = 1,
    Color2 = 2,
    Color3 = 3,
    Color4 = 4,
    Color5 = 5
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

public delegate TileElement TileElementConstructor(params object[] vars);

public class Constants
{

    public static readonly string[] TILE_ELEMENTS = new string[] {
        "Bramble",
        "Sigil",
        "Ground"
    };

    public static readonly Dictionary<string, TileElementConstructor> TILE_CONSTRUCTORS = new Dictionary<string, TileElementConstructor> {
        {"Bramble", Bramble.GenerateTileElement}
    };

}