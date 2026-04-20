using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenLinkString(string link)
    {
        Application.OpenURL(link);
    }
}
