TestFlightUnity
===============

Unity bindings for TestFlight


Folder Structure:
 - deps: Put the TestFlight SDK in here if you want to build from source.
 - dist: A Unity package that includes the binaries (armv7) and usage examples.
 - src:
    - TestFlightCBinding: A Xcode project and code that provides a simple C wrapper around the TestFlight SDK.
    - TestFlightUnity: A Monodevelop project that provides a C# wrapper around the pure C TestFlight SDK.
 - unity: An example Unity project that demonstrates how to use the TestFlightUnity plugin.

MIT License, see License.txt.
