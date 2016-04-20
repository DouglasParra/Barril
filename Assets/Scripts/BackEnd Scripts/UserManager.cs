using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Api.Requests;
using Facebook.Unity;

public class UserManager : MonoBehaviour
{

    public static UserManager instance;

    //These are the account details we want to pull in
    public string userName;
    public string userId;
    private string facebookId;

    // UILabel 
    // public Text userNameLabel;
    // public Image profilePicture;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    public void UpdateInformation()
    {
        //We send an AccountDetailsRequest
        new AccountDetailsRequest().Send((response) =>
        {
            //We pass the details we want from our response to the function which will update our information
            UpdateGUI(response.DisplayName, response.UserId, response.ExternalIds.GetString("FB").ToString());
        });
    }

    public void UpdateGUI(string name, string uid, string fbId)
    {
        userName = name;
        //userNameLabel.text = userName;
        userId = uid;
        facebookId = fbId;

        Debug.Log("UserName: " + name + "\n" +
                  "UserID: " + uid + "\n" +
                  "FacebookID: " + fbId);

        // https://graph.facebook.com/100000253293158/picture?width=128&height=128

        //FB.API("http://graph.facebook.com/" + facebookId + "/picture?width=128&height=128", Facebook.Unity.HttpMethod.GET, FbGetPicture);
    }

   /*private void FbGetPicture(IGraphResult result)
    {
        if (result.Texture != null)
            profilePicture.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
    }*/
}
