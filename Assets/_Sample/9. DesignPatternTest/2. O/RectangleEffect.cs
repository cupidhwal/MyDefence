using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID
{
    public class RectangleEffect : AreaOfEffect
    {
        public float m_width;
        public float m_height;

        public override float CalculateArea()
        {
            return m_width * m_height;
        }
    }
}