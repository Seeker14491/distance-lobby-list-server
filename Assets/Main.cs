using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class Main : MonoBehaviour {
    private HostData[] data;
    private WebServer ws;

    void Start() {
        MasterServer.ipAddress = "54.213.90.85";
        MasterServer.port = 23466;
        InvokeRepeating("RequestHostList", 0.0f, 10.0f);
        ws = new WebServer(SendResponse, "http://+:80/");
        ws.Run();
    }

    private void Update() {
        data = MasterServer.PollHostList();
    }

    private void RequestHostList() {
        MasterServer.RequestHostList("Distance");
    }

    private string SendResponse(HttpListenerRequest request) {
        string response;
        using (var stream = new MemoryStream()) {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ServerList));
            serializer.WriteObject(stream, new ServerList(data));
            stream.Seek(0, SeekOrigin.Begin);


            using (var streamReader = new StreamReader(stream)) {
                response = streamReader.ReadToEnd();
            }
        }
        
        return response;
    }
}
