using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Networking;


namespace PokeApiCSharp
{
    /// <summary>
    /// Generic unity image loader from WebRequest
    /// </summary>
    public class ImageLoader
    {
        public async Task<Texture2D> FetchTexture(string url)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);

            webRequest.SendWebRequest();

            while (!webRequest.isDone)
            {
                await Task.Delay(5);
            }

            if (webRequest.error != null)
            {
                Debug.Log(webRequest.error);
            }

            return ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
        }
    }
}