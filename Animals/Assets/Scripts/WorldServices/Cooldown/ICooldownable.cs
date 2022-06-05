using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICooldownable
{
    void CooldownStart();
    void CooldownEnd();
}
