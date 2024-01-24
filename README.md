# LcsApi

LcsApi is an unofficial API that MS Lifecycle Services uses to execute all the operations on LCS.

Since LCS does not provide OAuth flow authentication, this client uses Selenium in the background to gather the required authentication cookies.

Different geographic region connections are supported.

## Usage

First step is to instanciate a connection to Lifecycle Services

```csharp
BrowserAuthenticationOptions options = new BrowserAuthenticationOptions(username: "your username", password: "your password");
BrowserAuthenticationProvider provider = new BrowserAuthenticationProvider(options);

LcsConnection connection = new LcsConnection(provider); 
```
you can also specify a previously requested cookie if you want to avoid re-authentication

```csharp
var options = new BrowserAuthenticationOptions(cookies: "cookies");
```
There are currently three API clients available:
- **LcsApiClient** - Main client
- **LcsSizingApiClient** - Subscription estimations
- **LcsDiagnosticsApiClient** - Environment monitoring and diagnostics

To start using the client, request the connection to create it
```csharp
// Get the client
LcsApiClient client = await connection.GetClientAsync<LcsApiClient>();
```
this will trigger the authentication process in the background and will wait for completion.

You can now use the client
```csharp
// Retrieve project information 
Project? project = await client.GetProjectAsync(projectId: 666666);

// Gets environment details by id within a project
Guid environmentId = new Guid("00000000-0000-0000-0000-000000000000")
CloudHostedInstance? environment = await client.GetEnvironmentDetailsAsync(projectId: project.Id, environmentId: environmentId);

if (environment != null)
{
  // Request to start the environment
  bool startRequestedOk = await client.StartStopDeploymentAsync(projectId: project.Id, request: new StartStopDeploymentRequest(environment, CloudHostedEnvironmentAction.Start));
}
```
## Pending work
- Although the API is stable, since there is no documentation from Microsoft, there are still some endpoints and data models that are not fully discovered. That's why you will see some return *object* types.

- Currently, there is MFA support, but it will be reworked in the near future with a cleaner implementation.

- Test implementations
## License

[MIT](https://choosealicense.com/licenses/mit/)
