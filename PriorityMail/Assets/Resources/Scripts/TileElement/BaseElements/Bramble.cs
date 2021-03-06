﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble : Monocoord
{
    private Facet facing;

    public Bramble() { }

    private Bramble (params object[] vars)
    {
        SetCoords(new int[] {
            ((Vector3Int)vars[0]).x,
            ((Vector3Int)vars[0]).y,
            ((Vector3Int)vars[0]).z
        });
        facing = (Facet)vars[1];
    }

    public override void AdjustRender ()
    {

    }

    public override TileElement GenerateTileElement(params object[] vars)
    {
        return new Bramble(vars);
    }

    public override TileElement LoadTileElement(params object[] vars)
    {
        Bramble bramble = new Bramble(vars);
        bramble.SetPhysics(false, true, false, true);
        return bramble;
    }

    public override void CompileTileElement(ref LinkedList<int> dataInts, ref LinkedList<Shade> dataShades)
    {

    }

    public override TileElement DecompileTileElement(ref Queue<int> dataInts, ref Queue<Shade> dataShades)
    {
        return new Bramble();
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

    public override TileElementNames TileID ()
    {
        return TileElementNames.Bramble;
    }

    public Facet GetDirection ()
    {
        return facing;
    }
}
