# Distance Lobby List Server

This is a server that polls [Distance](http://survivethedistance.com/)'s lobby list, and serves the data as JSON through HTTP. It's implemented as a Unity project in order to have access to the same APIs Distance uses to query servers.

##### Example JSON returned

```json
{"servers":[{"build":5465,"connectedPlayers":1,"mode":"Sprint","passwordProtected":true,"playerLimit":24,"serverName":"Seekr's server"}]}
```



#### Building and Usage

The project should build in Unity without any additional configuration. Once the executable is running, the server will respond to HTTP requests with the server list. You can check if it's working by going to [http://localhost/](http://localhost/) in a web browser on the same computer.

I needed to run the executable with `sudo` on Ubuntu in order for the server to have access to the required port.

##### Running headless

The executable, being a Unity project, will by default create a graphical window. The window is quite useless, as nothing will be shown in it. When building for Linux, there is a headless mode toggle in the build settings, which allows creating an executable that doesn't create a useless window and will run on servers with no GPU:

![headless mode toggle](https://noobtuts.com/content/unity/unet-server-hosting/build_headless_mode.png)

On other platforms it should be possible to pass the `-batchmode -nographics` flags to the built executable (that would normally create the window) to accomplish the same thing, though I haven't tested this method.

