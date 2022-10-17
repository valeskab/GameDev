using UnityEngine;
[CreateAssetMenu]

public class CharacterCreatorSO : ScriptableObject
{
    public ClosetDatabase[] item;

    public int ItemCount
    {
        get
        {
            return item.Length;
        }
    }

    public ClosetDatabase GetItem(int index)
    {
        return item[index];
    }
}
