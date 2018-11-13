using System;
using UnityEngine;
namespace HybridGame
{
    public static class MathUtils
    {
        public static bool isZeroish(float value)
        {
            float ZEROISH = 0.00001f;
            return (ZEROISH > value && value > -ZEROISH);
        }
    }
}