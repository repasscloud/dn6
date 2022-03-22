# Remove folders
try { Remove-Item -Path $PSScriptRoot/Migrations -Recurse -Force -Confirm:$false -ErrorAction Stop } catch { }
try { Remove-item -Path $PSScriptRoot/Controllers -Recurse -Force -Confirm:$false -ErrorAction Stop } catch { }

# Engine Data Context
'Application','ExploitReport','VirusTotalScan','BaseImage','BaseImageEdition','Executable' | ForEach-Object {
    $i = $_
    dotnet aspnet-codegenerator controller -name "${i}sController" -m "${i}" -dc EngineDataContext -async -api -outDir Controllers
}
dotnet aspnet-codegenerator controller -name "ApplicationCategoriesController" -m "ApplicationCategory" -dc EngineDataContext -async -api -outDir Controllers
dotnet aspnet-codegenerator controller -name "UninstallProcessesController" -m "UninstallProcess" -dc EngineDataContext -async -api -outDir Controllers

# Shared Data Context
'Language','Locale','PackageDetection','TransferMethod' | ForEach-Object {
    $i = $_
    dotnet aspnet-codegenerator controller -name "${i}sController" -m "${i}" -dc SharedDataContext -async -api -outDir Controllers
}
dotnet aspnet-codegenerator controller -name "DetectionProcessesController" -m "DetectionProcess" -dc SharedDataContext -async -api -outDir Controllers
dotnet aspnet-codegenerator controller -name "CpuArchesController" -m "CpuArch" -dc SharedDataContext -async -api -outDir Controllers
dotnet aspnet-codegenerator controller -name "CountriesController" -m "Country" -dc SharedDataContext -async -api -outDir Controllers
