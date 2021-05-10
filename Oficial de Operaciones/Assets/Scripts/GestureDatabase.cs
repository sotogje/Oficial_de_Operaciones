using UnityEngine;

[CreateAssetMenu(fileName = "Gesture List", menuName = "Arm Gesture")]
public class GestureDatabase : ScriptableObject
{
    public GestureList[] Gestures;
    
    public int GestureCount
    {
        get { return Gestures.Length; }
    }

    public GestureList GetCharacter(int index)
    {
        return Gestures[index];
    }

}
