﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit()
    {
        Debug.Log(string.Format("{0} hit!", name));
    }
}
