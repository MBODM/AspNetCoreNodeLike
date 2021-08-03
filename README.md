# AspNetCoreNodeLike
A very basic Web Api example, using ASP.NET Core the Node.js style

#### What it is:

This is a tiny example of an ASP.NET Core Web Api, not using JSON ModelBinding or strongly typed DTO models.

#### Background:

I worked a lot with ASP.NET Core, before i stepped deeper into the JS/TS Node.js/Deno world. In a strongly typed environment like C#/.NET, paired with a rather strong opinionated framework like ASP.NET Core, things act very different.

For smaller projects we often struggled with huge time investments and some of the complexity ASP.NET Core brings on the table. Don't get me wrong: MS did some fantastic jobs there. But following the typical tutorial/docs default ways, often brought us rather fast into complex scenarios. It often took not much time, before we found ourselfes knee-deep in opinionated-framework-dependent situations, where using framework-stuff A leads to using framework-stuff B, forces us to use framework-stuff C and so on.

A typical snowball effect starts with using ModelBinding. This leads to some "mechanic", how validation and responses are handled. This leads again to how Logging must be done. This leads again to other things and so on. Many things quickly forced us more and more into the "MS way" or "ASP.NET Core way". This is not a bad thing per se. Because that way is well-formed in one framework. But it quickly increases learning curve and time investment. It's just the typical effect of an opinionated framework.

But sometimes you just wanna get some request, handle it and produce a response. And you wanna keep full direct control over Validation, Error-Handling, Logging and so on. In example: Sometimes you just wanna simply get the JSON request as string. You wanna validate the JSON by your own. Wanna log something by your own. And create an apropriate response by your own, dependent on your descisions. You don´t wanna handle with complex ModelBinding, writing RawTextFormatters or Custom ModelBinders, handling with ProblemDetails creation or complex routing stuff. All of this is embedded into the framework and done by a specific way. You have to turn specific knobs, framework-dependend, to reach your goals. It's just not that Swiss Army Knive, let you doing things quickly manually. It's more of a very complex US Army High Tech Tank. You first have to find out, how the hell you even start that thing.

Also C# is a strongly typed language. In contrast to JS. This means: In the ASP.NET Core world, you often use strongly typed DTO objects and model binding. Whereas in the JS world, you just open up some { } brackets and define a response. This means, in ASP.NET Core you have a lot of DTO classes and declared types. Which makes data transfers, conversions etc. rather statically and a bit tough as chewing gum.

#### That said:

This example was just a small test, in which way we can create a REST API in ASP.NET Core a bit more flexible. A bit more like in the Node.js or Deno world.

#### Final words:

Most interessting stuff happens in "MainController.cs" file. The example is rather small and clumsy, to keep things simple and obvious. There are a few comments in MainController, that follow what i said above. Also there is a comment, showing how to quickly test the API with some simple cURL call.

Dont expect much here. It was just some tiny test for myself. :)

Have fun
