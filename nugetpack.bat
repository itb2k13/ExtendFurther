del "D:\Repos\Personal\ExtendFurther\*.nupkg"
d:\nuget.exe pack "D:\Repos\Personal\ExtendFurther\package.nuspec" -OutputDirectory "D:\Repos\Personal\ExtendFurther\
d:\nuget.exe push "D:\Repos\Personal\ExtendFurther\*.nupkg" <API_KEY> -Source https://api.nuget.org/v3/index.json
pause