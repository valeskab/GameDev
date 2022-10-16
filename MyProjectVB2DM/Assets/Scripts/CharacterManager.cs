using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterCreatorSO soObj;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    void Start()
    {
        UpdateDress(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= soObj.DressCount)
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
            selectedOption = soObj.DressCount -1;
        }
        
        UpdateDress(selectedOption);
    }

    private void UpdateDress(int selectedOption)
    {
        ClosetDatabase dress = soObj.GetDress(selectedOption);
        artworkSprite.sprite = dress.itemSprite;
    }
}
