using UnityEngine;
[CreateAssetMenu]

public class CharacterCreatorSO : ScriptableObject
{
    public ClosetDatabase[] dress;

    public int ItemCount
    {
        get
        {
            return dress.Length;
        }
    }

    public ClosetDatabase GetItem(int index)
    {
        return dress[index];
    }
}
