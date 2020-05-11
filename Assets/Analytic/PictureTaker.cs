using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PictureTaker : SimpleLogger
{
    public int ImageWidth;
    public int ImageHeight;
    
    WebCamTexture webcamTexture;
    Texture2D texture2D;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        if(takePictures)
        {
            Debug.Log("iniciando camera");
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
        }
    }
    void OnDestroy()
    {
        if (takePictures)
        {
            webcamTexture.Stop();
        }
    }
    public void StopWebCamCapture()
    {
        webcamTexture.Stop();
    }

    public void TakePicture(string action)
    {
        Color[] pixels = webcamTexture.GetPixels();
        if (pixels.Length != 0)
        {
            if (texture2D == null || webcamTexture.width != texture2D.width || webcamTexture.height != texture2D.height)
            {
                texture2D = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
            }

            texture2D.SetPixels(pixels);
            byte[] jpg = texture2D.EncodeToJPG();
            string base64 = System.Convert.ToBase64String(jpg);

            StartCoroutine(UploadImage(action, base64));
        }
        
    }


}
