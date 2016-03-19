# Owin-Nancy-Tutorial
Tutorial for creating a Owin module using Nancy as rendering engine.


This is a very simple startup project that explain how to embed a web application into an assembly (yes, just a simple dll) and provide it as part of a web site.

## How to test it

1. download the code
2. restore packeges with nuget.exe restore
3. start web site
4. click on the red button

Project is composed by a web site and a library project. Web site is just a simple MVC web site use as container. It should represent the base site where you'll need to integrate an embedded site. Inside the library project there is some nancy configuration and a view used to rendere embedded web site.

## Showcase

In this project you can see in action:

1. How to create a web site inside a dll and integrare in a true web site o run it as standalone
2. How to parametrize roting for web site (i.e. how to installa a site inside a sub folder of the site)
3. How to serve static content from the assembly (yes we can!)
4. Hot to overwrite view from main site to customize rendering

#Notes

Today there are a missing class inside Nancy package released on nuget. This class is "EmbeddedStaticContentConventionBuilder" and is needed to serve static content from assembly, foundamental to keep resources as js,css, images inside external assembly.

Another problem is about "ResourceViewLocationProvider" that when find two view with same name it throw an exception. I implement my provider that overwite views allowing fallback logic on view engine.


