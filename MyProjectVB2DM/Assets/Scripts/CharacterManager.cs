using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterCreatorSO dressobj;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    void Start()
    {
        UpdateDress(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= dressobj.DressCount)
        {
            selectedOption = 0;
        }
        
        UpdateDress(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = dressobj.DressCount -1;
        }
        
        UpdateDress(selectedOption);
    }

    private void UpdateDress(int selectedOption)
    {
        ClosetDatabase dress = dressobj.GetDress(selectedOption);
        artworkSprite.sprite = dress.characterDress;
    }
}
