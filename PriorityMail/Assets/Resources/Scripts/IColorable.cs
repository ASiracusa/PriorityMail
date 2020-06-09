﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorable
{
    void SetShade(Shade shade, int index);

    void ColorFacets(Color32[] palette);
}
