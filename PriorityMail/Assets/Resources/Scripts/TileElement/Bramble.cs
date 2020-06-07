﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble : Monocoord
{
    private Facet facing;

    public Bramble() { }

    private Bramble (params object[] vars)
    {
        SetCoords((int[])vars[0]);
        facing = (Facet)vars[1];
    }

    public override TileElement GenerateTileElement(params object[] vars)
    {
        return new Bramble(vars);
    }

    public override EditorTEIndices[] GetEditorTEIndices()
    {
        return new EditorTEIndices[]
        {
            EditorTEIndices.Pos1,
            EditorTEIndices.Direction
        };
    }

    public override string TileName()
    {
        return "Bramble";
    }
}
