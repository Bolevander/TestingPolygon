﻿using System;
using UnityEngine;

namespace MVC
{
    class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis("Horizontal"));
        }
    }
}