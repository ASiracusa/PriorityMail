﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble : Monocoord
{
    private Facet facing;

    private Bramble (params object[] vars)
    {
        SetCoords((int[])vars[0]);
        facing = (Facet)vars[1];
    }

    public static TileElement GenerateTileElement(params object[] vars)
    {
        return new Bramble(vars);
    }
}