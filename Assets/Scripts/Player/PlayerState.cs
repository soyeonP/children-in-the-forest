using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public float hp = 100; // 체력
    public float full = 10; // 포만감
    // 공포

    private bool isSelected = false;

    public bool IsSelected() { return isSelected; }

    public void ChangeHP(float value)
    {
        // hp 확인 구간
        hp += value;
    }

    public void ChangeFull(float value)
    {
        // full 확인 구간
        full += value;
    }
}
