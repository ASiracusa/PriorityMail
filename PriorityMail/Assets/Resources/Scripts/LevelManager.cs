﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager current;

    private LevelData levelData;

    private TileElement[,,] board;
    private Bramble bramble;

    private Color32[] palette = new Color32[]
    {
        new Color32 (0x00, 0x00, 0x00, 0xFF),
        new Color32 (0x11, 0x00, 0x00, 0xFF),
        new Color32 (0x22, 0x00, 0x00, 0xFF),
        new Color32 (0x33, 0x00, 0x00, 0xFF),
        new Color32 (0x44, 0x00, 0x00, 0xFF),
        new Color32 (0x55, 0x00, 0x00, 0xFF),
        new Color32 (0x66, 0x00, 0x00, 0xFF),
        new Color32 (0x77, 0x00, 0x00, 0xFF),
        new Color32 (0x88, 0x00, 0x00, 0xFF),
        new Color32 (0x99, 0x00, 0x00, 0xFF),
        new Color32 (0xAA, 0x00, 0x00, 0xFF)
    };

    // Start is called before the first frame update
    void Start()
    {
        current = this;

        LoadLevel("auburn", "heights");
        StartCoroutine(BrambleInput());
    }

    private void LoadLevel (string worldName, string levelName)
    {
        levelData = (LevelData)SerializationManager.LoadLevel(Application.persistentDataPath + "/worlds/" + worldName + "/" + levelName + ".lvl");
        print(levelData.sigilCoords[0]);
        TileElement tileModel = Constants.TILE_MODELS[(int)TileElementNames.Ground];

        board = new TileElement[levelData.grounds.GetLength(0), levelData.grounds.GetLength(1), levelData.grounds.GetLength(2)];
        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y ++)
            {
                for (int z = 0; z < board.GetLength(2); z++)
                {
                    if (levelData.grounds[x, y, z] != null)
                    {
                        board[x, y, z] = tileModel.LoadTileElement(new object[] {
                            new Vector3Int(x, y, z),
                            levelData.grounds[x, y, z]
                        });
                        board[x, y, z].model = Instantiate(Resources.Load("Models/Ground")) as GameObject;
                        board[x, y, z].BindDataToModel();
                        board[x, y, z].MoveToPos();
                        ((Ground)board[x, y, z]).ColorFacets(palette);
                    }
                }
            }
        }

        bramble = (Bramble)Constants.TILE_MODELS[(int)TileElementNames.Bramble].LoadTileElement(new object[]
        {
            new Vector3Int(levelData.brambleCoords[0], levelData.brambleCoords[1], levelData.brambleCoords[2]),
            levelData.brambleDirection
        });
        bramble.model = Instantiate(Resources.Load("Models/Ground")) as GameObject;
        bramble.BindDataToModel();
        bramble.MoveToPos();
        board[bramble.GetPos().x, bramble.GetPos().y, bramble.GetPos().z] = bramble;

        board[levelData.sigilCoords[0], levelData.sigilCoords[1], levelData.sigilCoords[2]] = (Sigil)Constants.TILE_MODELS[(int)TileElementNames.Sigil].LoadTileElement(new object[]
        {
            new Vector3Int(levelData.sigilCoords[0], levelData.sigilCoords[1], levelData.sigilCoords[2]),
        });
        board[levelData.sigilCoords[0], levelData.sigilCoords[1], levelData.sigilCoords[2]].model = Instantiate(Resources.Load("Models/Sigil")) as GameObject;
        board[levelData.sigilCoords[0], levelData.sigilCoords[1], levelData.sigilCoords[2]].BindDataToModel();
        board[levelData.sigilCoords[0], levelData.sigilCoords[1], levelData.sigilCoords[2]].MoveToPos();
    }

    private void MoveBramble (Facet direction) 
    {
        bramble.Push(board, direction);
    }

    private IEnumerator BrambleInput ()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveBramble(Facet.North);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MoveBramble(Facet.South);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveBramble(Facet.West);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveBramble(Facet.East);
            }
            yield return null;
        }
    }
}