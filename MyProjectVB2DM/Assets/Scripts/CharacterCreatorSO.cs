using UnityEngine;
[CreateAssetMenu]

public class CharacterCreatorSO : ScriptableObject
{
    public ClosetDatabase[] dress;

    public int DressCount
    {
        get
        {
            return dress.Length;
        }
    }

    public ClosetDatabase GetDress(int index)
    {
        return dress[index];
    }
}
