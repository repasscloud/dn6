# list of contexts
[System.String[]]$Contexts = 'SharedDataContext','EngineDataContext'

foreach ($context in $Contexts)
{
    dotnet ef database update --context $context
}

