using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID
{
    public class CircleEffect : AreaOfEffect
    {
        public float m_Radius;

        public override float CalculateArea()
        {
            return m_Radius * m_Radius * Mathf.PI;
        }
    }
}