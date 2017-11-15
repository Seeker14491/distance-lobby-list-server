using System.Net;
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

        if (data.Length == 0) {
            response = "No Servers";
        } else {
            response = "";
            foreach (var hostData in data) {
                var si = new ServerInfo(hostData);
                var status = si.PasswordProtected() ? "Private" : "Public";
                response += $"({si.Mode()}) {si.ServerName()}\n{si.ConnectedPlayers()}/{si.PlayerLimit()}  {status}  v{si.Build()}\n\n";
            }
        }

        return response;
    }
}
