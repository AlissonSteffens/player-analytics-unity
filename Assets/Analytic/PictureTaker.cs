using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PictureTaker : SimpleLogger
{
    public int ImageWidth;
    public int ImageHeight;
    public int CaptureInterval;
    WebCamTexture webcamTexture;
    Texture2D texture2D;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        if(takePictures)
        {
            StartWebCamCapture();
        }
        
    }

    void StartWebCamCapture()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }
        if (devices.Length > 0)
        {
            webcamTexture = new WebCamTexture(devices[0].name, ImageWidth, ImageHeight);
            Debug.Log(webcamTexture);
            Renderer r = GetComponent<Renderer>();
            if (r != null)
            {
                Material m = r.material;
                if (m != null)
                {
                    m.mainTexture = webcamTexture;
                }
            }
            webcamTexture.Play();
            StartCoroutine("Capture");
        }
    }

    private IEnumerator Capture()
    {
        while (true)
        {

            yield return new WaitForSeconds(CaptureInterval);

            Color[] pixels = webcamTexture.GetPixels();
            if (pixels.Length == 0)
                yield return null;
            if (texture2D == null || webcamTexture.width != texture2D.width || webcamTexture.height != texture2D.height)
            {
                texture2D = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
            }

            texture2D.SetPixels(pixels);
            // texture2D.Apply(false); // Not required. Because we do not need to be uploaded it to GPU
            byte[] jpg = texture2D.EncodeToJPG();
            string base64 = System.Convert.ToBase64String(jpg);
            StartCoroutine(Upload(base64));
        }
    }

    IEnumerator Upload(string image)
    {
        WWWForm json = new WWWForm();
        json.AddField("user", user);
        json.AddField("game", game);
        json.AddField("category", "image");
        json.AddField("action", "stateChanged");
        json.AddField("value", "data:image/jpeg;base64,"+image);
        json.AddField("time", System.DateTime.UtcNow.ToString());

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
                Debug.Log("enviou foto");
        }
    }
}
