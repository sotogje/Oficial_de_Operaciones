using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TargetCode
{
    NA, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
}

[System.Serializable]
public class GestureList
{
    public new string name;
    [Range(0, 1)] public float TimeForRaycastToRegister = 0.2f;
    [Range(0, 3)] public float TimeLeftUntilHitNextColider = 2.0f;
    public List<TargetCode> leftHandList = new List<TargetCode>();
    public List<TargetCode> rightHandList = new List<TargetCode>();    
}
