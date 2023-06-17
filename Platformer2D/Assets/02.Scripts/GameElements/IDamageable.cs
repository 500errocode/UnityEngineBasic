using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{

    float hp { get; set; }
    float hpMax { get; }
    float hpMin { get; }
    event Action<float> onHpChanged;
    event Action<float> onHplncreased;
    event Action<float> onHpDecreased;
    event Action onHpMax;
    event Action onHpMin;
    void Damage(GameObject damager, float amout);
}
