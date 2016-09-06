# Groove User Authentication Samples

User authentication for the Groove API is detailed in the [User Authentication documentation](User Authentication.md). Make sure you've read this documentation before using the samples provided here. In case you're building a website you should use OAuth instead of the following samples.

But if you're developing an application, you should try to leverage existing libraries for the platform your application will be running on.
Such libraries exist on Windows, Windows Phone, Xbox, Android and iOS.

## Windows 10 (Universal Application)
You can use the following sample code in universal applications, which means it can run on Windows 10, Windows Phone 10 and Xbox One.

You can find [here](https://msdn.microsoft.com/en-us/windows/uwp/security/web-account-manager) a detailed documentation on how you should manage user accounts in your application.

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
You can use the following sample code on Windows 8, Windows 8.1, Windows Phone 8 and Windows Phone 8.1.

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
