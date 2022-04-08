using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    // Va servir pour déterminer ce qui est touché et comment ce qui est touché réagit
    void TakeDamage(bool Degats);

}
