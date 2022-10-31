using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBehaviour : MonoBehaviour
{
    
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
    private void UpdateItem(int selectedOption)
    {
        ClosetDatabase item = soObj.GetItem(selectedOption);
        artworkSprite.sprite = item.itemSprite;
    }
    
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
