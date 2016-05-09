# Cake.ViewCompiler

![Build Status][vsts-build]
[![NuGet](https://img.shields.io/nuget/v/Cake.ViewCompiler.svg?maxAge=3600?style=flat-square)](https://www.nuget.org/packages/Cake.ViewCompiler/)

## Introduction

This simple Cake addin is designed to simplify the build process when using CouchDB views.

## Usage

```csharp
#addin "Cake.ViewCompiler"
Task("Generate-Views")
.Does(() => {
	var samplePaths = GetFiles("./Views/*.js");
	ViewCompiler("events")
		.FromFiles(samplePaths)
		.Create("./design-doc.json");
});
```

That will create a simple `design-doc.json` file in your current directory based on any `.js` files in the Views directory.

## View Files

Rather than managing an unwieldy design document with an obtuse structure, just keep a series of `.js` files, named for their view name, with the function as their content.

That is, for a view named `events`, just create a file called `events.js` with the following as the content:

```javascript
function(doc) {
	if (doc.$doctype !== 'eventSource') return;
	emit(doc.name, doc.events.length);
}
```

Now, just make sure your Cake script includes that file in the call to `ViewCompiler` and the view will natively show up in the target design document.

## License and Credits

Credit to Icons8 for the icon, to the Cake team for an awesome tool and to the JSON.NET project for the JSON-handling code.

[vsts-build]: https://vs01.visualstudio.com/DefaultCollection/_apis/public/build/definitions/09d675bd-0b92-45dc-8a6c-f8c4976b4ef0/15/badge
