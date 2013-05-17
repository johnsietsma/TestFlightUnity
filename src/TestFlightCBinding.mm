#import "TestFlight.h"

#import <UIKit/UIDevice.h>

/**
 * A C wrapper around the Objective C TestFlight SDK.
 * This is for use with the p/invoke CSharp wrapper.
 * Find the API documentation here: "https://testflightapp.com/sdk/doc/1.2/">
 */
extern "C" {
    void TF_TakeOff( const char* teamToken ) {
        NSString* teamTokenNSString = [NSString stringWithCString:teamToken encoding:NSUTF8StringEncoding];
        [TestFlight takeOff:teamTokenNSString];
    }

    void TF_PassCheckpoint(const char* checkpoint)
    {
        [TestFlight passCheckpoint:[NSString stringWithUTF8String:checkpoint]];
    }

    void TF_AddCustomEnvironmentInformation( const char* info, const char* key ) {
        NSString* infoNSString = [NSString stringWithCString:info encoding:NSUTF8StringEncoding];
        NSString* keyNSString = [NSString stringWithCString:key encoding:NSUTF8StringEncoding];
        [TestFlight addCustomEnvironmentInformation:infoNSString forKey:keyNSString];
    }

    void TF_OpenFeedbackView() {
        [TestFlight openFeedbackView];
    }

    void TF_SendFeedback( const char* feedback ) {
        NSString* feedbackNSString = [NSString stringWithCString:feedback encoding:NSUTF8StringEncoding];
        [TestFlight submitFeedback:feedbackNSString];
    }

    void TF_SetDeviceID() {
        [TestFlight setDeviceIdentifier:[[UIDevice currentDevice] uniqueIdentifier]];
    }

    void TF_Log( const char* msg ) {
        NSString* msgNSString = [NSString stringWithCString:msg encoding:NSUTF8StringEncoding];
        TFLog( msgNSString );
    }

    void TF_Crash() {
        char* c = NULL;
        *c = 'a';
    }
}
