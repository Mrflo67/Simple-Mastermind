
using UnityEngine;
using UnityEngine.UI;

public class caseScript : MonoBehaviour
{
    public void SelectCase()
    {
        GameManager.instance.selectedHole = gameObject;

        gameObject.GetComponent<Image>().color = GameManager.instance._gapColor;

    }
}
