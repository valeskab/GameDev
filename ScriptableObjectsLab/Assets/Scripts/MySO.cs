using UnityEngine;

[CreateAssetMenu(fileName = "Character Creator", menuName = "Character")]
public class MySO : ScriptableObject
{
    public string characterName;
    public string characterClass;
    public string attackType;
    public float attackRange;
    public float exp;
    public int attackDamage;
    public int level;

    public void Print()
    {
        Debug.Log(characterName + ":" + characterClass + "Level:" + level + "Exp:" + exp + "/100");
    }
}
