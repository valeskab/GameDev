using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ItemDisplay : MonoBehaviour
{
    public UnityEvent accesoryEvent, dressEvent, shoesEvent;
    public AccesoryID accesory;
    public Image artworkImage;

    public CharacterCreatorSO characterCreator;
    public GameObject dressObj;

    private void AccesoryEvent()
    {
        accesoryEvent.Invoke();
    }
    void Start()
    {
        artworkImage.sprite = accesory.artwork;

        
    }

}