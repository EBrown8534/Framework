# Evbpc.Framework

This repository is a bulk repository for cloning many functions of `System.Drawing`, `System.Windows` and `System.Windows.Forms` in an XNA-compatible form, as well as other various utilities and objects for performing various tasks.

This repository was originally created for another project of mine, hence the naming.

## Included projects

* `Evbpc.Framework`: contains the root utilities, classes and structures to replicate certain portions of the `System.Drawing` namespace, as well as limited support for certain physics operations, and a small list of additional utilities (for serialization, logging, etc.).
* `Evbpc.Framework.Windows`: contains the additional features required to create `Form` objects within XNA (or other graphics libraries, this project is library agnostic).
* `Evbpc.Framework.Xna`: contains the wrapping of the `Evbpc.Framework` and `Evbpc.Framework.Windows` projects to XNA-compatible formats, as well as other XNA-specific utilities.

## What can you do with it

Anyone is free to use this to their own purposes, I only request that if you make substantial changes you create a pull-request to include them in this repository.

## How do I use it

This solution requires Visual Studio 2013, XNA 4.0, and .NET 4.5. Detailed setup instructions are below.

## Setting up XNA 4.0

To setup XNA 4.0 on your PC for integration with Visual Studio 2013, please read [this article](https://mxa.codeplex.com/wikipage?title=How%20install%20XNA%204.0%20on%20Visual%20Studio%202013&referringTitle=Documentation) on the issue.
