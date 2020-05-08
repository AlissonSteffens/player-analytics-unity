using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleLogger : MonoBehaviour
{
    public string ApiEndpoint;
    protected string apiURL;
    protected string user;
    protected string game;
    protected bool isDebugging;
    protected bool takePictures;
    protected bool doKeyLogger;
    protected bool doMouseLogger;
    protected bool doScoreLogger;
    protected bool doStateLogger;
    protected bool doFlowLogger;
    protected Animator stateAnimator;
    protected Animator dialogController;
    protected SectionController sectionController;
    protected string section = "";
    protected bool backup;

    private string dados = "";
    // Start is called before the first frame update
    protected void Start()
    {
        Analytic analytic = GetComponent<Analytic>();
        apiURL = analytic.ApiURL;
        user = analytic.User;
        isDebugging = analytic.IsDebugging;
        takePictures = analytic.TakePictures;
        doKeyLogger = analytic.KeyLogger;
        doScoreLogger = analytic.ScoreLogger;
        doMouseLogger = analytic.MouseLogger;
        doStateLogger = analytic.StateLogger;
        game = analytic.Game;
        stateAnimator = analytic.Character;
        dialogController = analytic.DialogController;
        doFlowLogger = analytic.FlowLogger;
        backup = analytic.DoBackup;
        sectionController = new SectionController();
    }

    protected IEnumerator Upload(string values)
    {
        string[] data = values.Split(',');
        return FullUpload(data, System.DateTime.Now.ToString());
    }

    protected IEnumerator UploadImage(string action, string image)
    {
        string[] data = new string[4];
        data[0] = "image";
        data[1] = action;
        data[2] = "b64";
        data[3] = "data:image/jpeg;base64,"+image;
        return FullUpload(data, System.DateTime.Now.ToString());
    }

    protected IEnumerator FullUpload(string[] data,string time)
    {
        
        WWWForm json = new WWWForm();
        json.AddField("user", user);
        json.AddField("game", game);
        json.AddField("platform", Application.platform.ToString());
        json.AddField("category", data[0]);
        json.AddField("action", data[1]);
        if (data.Length >= 3)
        {
            json.AddField("label", data[2]);
        }
        if (data.Length >= 4)
        {
            json.AddField("value", data[3]);
        }
        json.AddField("time", time);

        if (section.Equals(""))
        {
            section = sectionController.GenerateSectionHash(user);
        }
        json.AddField("section", section);

        if (backup)
        {
            dados = user + "," + game + "," + Application.platform.ToString() + "," + data[0] + "," + data[1] + "," + (data.Length >= 3 ? data[2] : "NaN") + "," + (data.Length >= 4 ? data[3] : "NaN") + "," + time + "," + section+"\n";
            File.AppendAllText("backup.dat", dados);
        }
        

        UnityWebRequest www = UnityWebRequest.Post(apiURL + ApiEndpoint, json);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (isDebugging)
                Debug.Log("enviou " + data[0] + " - " + data[1]);
        }
    }

}
