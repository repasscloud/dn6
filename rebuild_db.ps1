# list of contexts
[System.String[]]$Contexts = 'SharedDataContext','EngineDataContext'

foreach ($context in $Contexts)
{
    dotnet ef migrations add "AddTables${context}" --context $context
    dotnet ef database update --context $context
}
