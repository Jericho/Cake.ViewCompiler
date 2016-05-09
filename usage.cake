#r dist/build/Cake.ViewCompiler/Cake.ViewCompiler.dll

var samplePaths = GetFiles("./Views/*.js");


Task("Test")
.Does(() => {
	ViewCompiler("events").FromFiles(samplePaths).WriteToFile("./design-doc.json");
});

RunTarget("Test");