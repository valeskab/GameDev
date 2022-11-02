using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    //Script Reference provided by Hooson on youtube https://www.youtube.com/watch?v=2PKBChN10us
    public CharacterCreatorSO soObj;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateItem(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= soObj.ItemCount)
        {
            selectedOption = 0;
        }
        
        UpdateItem(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = soObj.ItemCount -1;
        }
        
        UpdateItem(selectedOption);
        Save();
    }
    
    public void Randomize()
    {
        selectedOption = Random.Range(0, soObj.ItemCount - 1);
        UpdateItem(selectedOption);
        Save();
    }

    private void UpdateItem(int selectedOption)
    {
        ClosetDatabase item = soObj.GetItem(selectedOption);
        artworkSprite.sprite = item.itemSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
