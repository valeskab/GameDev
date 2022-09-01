using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextLabelBehavior : MonoBehaviour
{
    public Text label;
    public FloatData dataObj;

    private void start()
    {
        label = GetComponent<Text>();
        label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
