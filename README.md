BibTeXtoHtmlConverter

This is WindowsForm client GUI source code. Written in C#. Works under MONO and .NET.

This is a main part of my engineer's thesis. Current name is linked with my engineer's thesis title("Application to convertion BibTeX bibliographic data to HTML"). I will change it in future for "Bibliographic Converter", because this program could make conversion between diffrent types of bibliographic data and allow to export data to some formats(xml fo example).

2 written by me work libraries "BibTeX.dll" and "BibToHtml.dll" are inlcuded as binaries.

Source code of BibManFunctionality.dll includes interfaces for work libraries is avanailbe in another repository on my GitHub. If you want to write .dll for another bibliographic or output format, you will need to implement this interfaces. (WARRING - this is still unfinished - some interfaces might change).

I will make avanaible all source code afrer my graduation if my university won't prohibid me that.

Current version is non-extensible. In near future, I will add plug-in manager, and all work libraries will disapear from client source code. User will be able to add or remove them as input and output plugins.
