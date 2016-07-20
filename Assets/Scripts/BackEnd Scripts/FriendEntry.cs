using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Facebook.Unity;

public class FriendEntry : MonoBehaviour
{
    public Image profilePicture;

    public void UpdateFriendImage(string facebookID)
    {
        // me/picture?type=square&height=64&width=64 - imagem própria
        FB.API(facebookID + "/picture?type=square&height=64&width=64", Facebook.Unity.HttpMethod.GET, FbGetPicture);
    }

    public void UpdateOwnImage()
    {
        FB.API("me/picture?type=square&height=64&width=64", Facebook.Unity.HttpMethod.GET, FbGetPicture);
    }

    private void FbGetPicture(IGraphResult result)
    {
        if (result.Texture != null)
            profilePicture.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 64, 64), new Vector2());
    }
}