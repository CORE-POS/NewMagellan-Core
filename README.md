# NewMagellan Core

This is a refactor of the NewMagellan driver to be buildable with
the newer .NET Core toolchain. Datacap support requires .NET
Core verison 3; otherwise it should be buildable with 2+.

Will make use of environment variable NewMagellanRoot if present.
Different build/publish options drop the binaries in different
places. Pointing the environment variable at a lane installation
can be a simpler way of letting this app locate the configuration
file(s) and correct ss-output directory
