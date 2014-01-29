#define EDITOR_VERBOSE
//#define WARN_NOT_SUPPORTED_ACTION
//#define WARN_NOT_SUPPORTED_PLATFORM

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TestFlightUnity
{
/// <summary>
/// The p/invoke wrapper around the C binding of the TestFlight SDK.
// <see href="https://testflightapp.com/sdk/doc/">
/// </summary>
#if UNITY_EDITOR && UNITY_ANDROID
[UnityEditor.InitializeOnLoad]
#endif
public static class TestFlight
{
	#if UNITY_EDITOR
		#if UNITY_ANDROID
		static TestFlight()
		{
			const string PropertiesFile = "Assets/Plugins/Android/res/raw/tf.properties";
			var obj = Resources.LoadAssetAtPath<UnityEngine.Object>( PropertiesFile );
			if ( obj == null )
				Debug.LogWarning( string.Format("TestFlight for Android requires a {0} file.", PropertiesFile) );
		}
		#endif

		public static void TakeOff( string token )
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight TakeOff: " + token );
			#endif
		}

		public static void PassCheckpoint( string checkpoint )
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight PassCheckpoint: " + checkpoint );
			#endif
		}

		public static void AddCustomEnvironmentInformation( string info, string key )
		{
			#if EDITOR_VERBOSE
			Debug.Log( string.Format("TestFlight AddCustomEnvironmentInformation: {0} = {1}", info, key) );
			#endif
		}

		public static void OpenFeedbackView()
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight OpenFeedbackView" );
			#endif
		}

		public static void SendFeedback( string feedback )
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight SendFeedback: " + feedback );
			#endif
		}

		public static void SetDeviceID()
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight SetDeviceID" );
			#endif
		}

		public static void Log( string msg )
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight Log: " + msg );
			#endif
		}

		public static void Crash()
		{
			#if EDITOR_VERBOSE
			Debug.Log( "TestFlight Crash" );
			#endif
		}
	#elif UNITY_IPHONE
		[DllImport ( "__Internal" )]
		private static extern void TF_TakeOff( string token );

		[DllImport ( "__Internal" )]
		private static extern void TF_PassCheckpoint( string checkpoint );

		[DllImport ( "__Internal" )]
		private static extern void TF_AddCustomEnvironmentInformation( string info, string key );

		[DllImport ( "__Internal" )]
		private static extern void TF_OpenFeedbackView();

		[DllImport ( "__Internal" )]
		private static extern void TF_SendFeedback( string feedback );

		[DllImport ( "__Internal" )]
		private static extern void TF_SetDeviceID();

		[DllImport ( "__Internal" )]
		private static extern void TF_Log( string msg );

		[DllImport ( "__Internal" )]
		private static extern void TF_Crash();

		public static void TakeOff( string token )
		{
			TF_TakeOff( token );
		}

		public static void PassCheckpoint( string checkpoint )
		{
			TF_PassCheckpoint( checkpoint );
		}

		public static void AddCustomEnvironmentInformation( string info, string key )
		{
			TF_AddCustomEnvironmentInformation( info, key );
		}

		public static void OpenFeedbackView()
		{
			TF_OpenFeedbackView();
		}

		public static void SendFeedback( string feedback )
		{
			TF_SendFeedback( feedback );
		}

		public static void SetDeviceID()
		{
			TF_SetDeviceID();
		}

		public static void Log( string msg )
		{
			TF_Log( msg );
		}

		public static void Crash()
		{
			TF_Crash();
		}
	#elif UNITY_ANDROID
		static AndroidJavaClass tf;
		
		public static void TakeOff( string token )
		{
			using ( AndroidJavaClass jc = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" ) )
				using ( AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>( "currentActivity" ) )
					using ( AndroidJavaObject app = activity.Call<AndroidJavaObject>( "getApplicationContext" ) )
						CallJavaTF( "takeOff", app, token );
		}

		public static void PassCheckpoint( string checkpoint )
		{
			CallJavaTF( "passCheckpoint", checkpoint );
		}

		public static void AddCustomEnvironmentInformation( string info, string key )
		{
			#if WARN_NOT_SUPPORTED_ACTION
			Debug.LogWarning( string.Format("TestFlight AddCustomEnvironmentInformation not supported: {0} = {1}", info, key) );
			#endif
		}

		public static void OpenFeedbackView()
		{
			#if WARN_NOT_SUPPORTED_ACTION
			Debug.LogWarning( "TestFlight OpenFeedbackView not supported" );
			#endif
		}

		public static void SendFeedback( string feedback )
		{
			#if WARN_NOT_SUPPORTED_ACTION
			Debug.LogWarning( "TestFlight SendFeedback not supported: " + feedback );
			#endif
		}

		public static void SetDeviceID()
		{
			#if WARN_NOT_SUPPORTED_ACTION
			Debug.LogWarning( "TestFlight SetDeviceID not supported" );
			#endif
		}

		public static void Log( string msg )
		{
			CallJavaTF( "log", msg );
		}

		public static void Crash()
		{
			#if WARN_NOT_SUPPORTED_ACTION
			Debug.LogWarning( "TestFlight Crash not supported" );
			#endif
		}

		static void CallJavaTF( string method, params object[] args )
		{
			if ( tf == null )
				tf = new AndroidJavaClass( "com.testflightapp.lib.TestFlight" );
			tf.CallStatic( method, args );
		}
	#else
		public static void TakeOff( string token )
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight TakeOff, platform not supported: " + token );
			#endif
		}

		public static void PassCheckpoint( string checkpoint )
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight PassCheckpoint, platform not supported: " + checkpoint );
			#endif
		}

		public static void AddCustomEnvironmentInformation( string info, string key )
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( string.Format("TestFlight AddCustomEnvironmentInformation, platform not supported: {0} = {1}", info, key) );
			#endif
		}

		public static void OpenFeedbackView()
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight OpenFeedbackView, platform not supported" );
			#endif
		}

		public static void SendFeedback( string feedback )
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight SendFeedback, platform not supported: " + feedback );
			#endif
		}

		public static void SetDeviceID()
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight SetDeviceID, platform not supported" );
			#endif
		}

		public static void Log( string msg )
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight Log, platform not supported: " + msg );
			#endif
		}

		public static void Crash()
		{
			#if WARN_NOT_SUPPORTED_PLATFORM
			Debug.LogWarning( "TestFlight Crash, platform not supported" );
			#endif
		}
	#endif
}
}