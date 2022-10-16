using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ItemDisplay : MonoBehaviour
{
    public AccesoryID accesory;
    public Image artworkImage;
    
    void Start()
    {


        artworkImage.sprite = accesory.artwork;

        
    }

}