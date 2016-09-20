---
author: bastuc
---

# Groove User Authentication in your Application

In this section, you'll learn how to sign your user in on many platforms.

## Windows 10 (Universal Application)
### Reserve an application name
You will need to reserve an application name to run code that leverages user authentication with the standard libraries. Go to the [Microsoft Developer Center](https://developer.microsoft.com/en-us/dashboard/apps/) and create a new application if you don't already have one. The name you choose will be reserved for your application and will allow you to use the user authentication libraries.

In Visual Studio 2015, you will need to associate your application to the one reserved on the Microsoft Developer Center. To do that, simply right-click on your project and select "Store -> Associate App with the Store...", select your application in the drop-down and follow the steps.

### SDK and sample code
You can use the following sample code on all Windows universal platforms.

You can find [our SDK on Github](https://github.com/Microsoft/groove-api-sdk-csharp) for universal applications. It handles errors and token refresh for you.

More code samples for universal applications can be found on [Github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/WebAccountManagement).

```csharp
private async Task<WebAccountProviderCommand> CreateWebAccountProviderCommand()
{
    var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
          "https://login.microsoft.com",
          "consumers");

    var command = new WebAccountProviderCommand(msaProvider, GetMsaTokenAsync);
    return command;
}

private async void GetMsaTokenAsync(WebAccountProviderCommand command)
{
    WebTokenRequest request = new WebTokenRequest(
        command.WebAccountProvider,
        "MicrosoftMediaServices.GrooveApiAccess");
    WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
    if (result.ResponseStatus == WebTokenRequestStatus.Success)
    {
        string token = "Bearer " + result.ResponseData[0].Token;
    }
    else
    {
        // Handle error cases
    }
}
```

## Windows and Windows Phone 8(.1)

You can use the following sample code on Windows 8, Windows 8.1, Windows Phone 8 and Windows Phone 8.1. If you plan on supporting Windows 10 universal platforms, it is recommended you use the samples above instead of this one.

```csharp
const string scope = "MicrosoftMediaServices.GrooveApiAccess";

// Authenticate the user
OnlineIdAuthenticator authenticator = new OnlineIdAuthenticator();
OnlineIdServiceTicketRequest request = new OnlineIdServiceTicketRequest(scope, "DELEGATION");
UserIdentity userAuth = await authenticator.AuthenticateUserAsync(request);
OnlineIdServiceTicket ticket = userAuth.Tickets.FirstOrDefault();

// The ticket obtained, prefixed by Bearer can now be sent in the Authorization header
return "Bearer " + ticket.Value;
```

## Android

On Android, you can use the [Live SDK for Android](https://msdn.microsoft.com/en-us/library/office/dn631814.aspx).

```java
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent"
    android:orientation="vertical" >
    <TextView
        android:id="@+id/resultTextView"
        android:layout_width="fill_parent"
        android:layout_height="wrap_content"
        android:text="Results will display here." />
</LinearLayout>

package com.live.dev;

import android.app.Activity;
import android.os.Bundle;
import android.widget.TextView;
import java.util.Arrays;
import com.microsoft.live.LiveAuthException;
import com.microsoft.live.LiveAuthListener;
import com.microsoft.live.LiveAuthClient;
import com.microsoft.live.LiveConnectSession;
import com.microsoft.live.LiveConnectClient;
import com.microsoft.live.LiveStatus;

public class JavaCodeSample extends Activity implements LiveAuthListener {

    private LiveAuthClient auth;
    private LiveConnectClient client;
    private TextView resultTextView;    

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        this.resultTextView = (TextView)findViewById(R.id.resultTextView);
        this.auth = new LiveAuthClient(this, MyConstants.APP_CLIENT_ID);
    }

    @Override
    protected void onStart() {
        super.onStart();
        Iterable<String> scopes = Arrays.asList("MicrosoftMediaServices.GrooveApiAccess");
        this.auth.login(scopes, this);
    }

    public void onAuthComplete(LiveStatus status, LiveConnectSession session, Object userState) {
        if(status == LiveStatus.CONNECTED) {
            this.resultTextView.setText("Signed in.");
            client = new LiveConnectClient(session);
        }
        else {
            this.resultTextView.setText("Not signed in.");
            client = null;
        }        
    }

    public void onAuthError(LiveAuthException exception, Object userState) {
        this.resultTextView.setText("Error signing in: " + exception.getMessage());        
        client = null;        
    }
}
```

## iOS

On iOS, you can use the [Live SDK for iOS](https://msdn.microsoft.com/en-us/library/hh875197.aspx).

```objc
#import <UIKit/UIKit.h>
#import "LiveSDK/LiveConnectClient.h"

@interface ViewController : UIViewController<LiveAuthDelegate, LiveOperationDelegate, LiveDownloadOperationDelegate, LiveUploadOperationDelegate>
@property (strong, nonatomic) LiveConnectClient *liveClient;
@property (strong, nonatomic) IBOutlet UILabel *infoLabel;
@end

#import "ViewController.h"

@implementation ViewController
@synthesize liveClient;
@synthesize infoLabel;

NSString* APP_CLIENT_ID=@"000000004406774C";

- (void)viewDidLoad
{
    [super viewDidLoad];
    self.liveClient = [[LiveConnectClient alloc] initWithClientId:APP_CLIENT_ID
                                                         delegate:self
                                                        userState:@"initialize"];
}

- (void)authCompleted:(LiveConnectSessionStatus) status
              session:(LiveConnectSession *) session
            userState:(id) userState
{
    if ([userState isEqual:@"initialize"])
    {
        [self.infoLabel setText:@"Initialized."];
        [self.liveClient login:self
                        scopes:[NSArray arrayWithObjects:@"MicrosoftMediaServices.GrooveApiAccess", nil]
                      delegate:self
                     userState:@"signin"];
    }
    if ([userState isEqual:@"signin"])
    {
        if (session != nil)
        {
            [self.infoLabel setText:@"Signed in."];        
        }
    }
}

- (void)authFailed:(NSError *) error
         userState:(id)userState
{
    [self.infoLabel setText:[NSString stringWithFormat:@"Error: %@", [error localizedDescription]]];
}
@end
```

## Related topics

The following topics contain high-level overviews of other concepts that apply
to user authentication for the Groove API.

* [User Authentication](User Authentication.md)
* [User Authentication on the Web](User Authentication on the Web.md)
