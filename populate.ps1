# country
$list = Get-Content -Path $PSScriptRoot/country_list.txt -Encoding UTF8
foreach ($c in $list)
{
    $Body = @{
        id = 0
        name = "${c}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/Countries' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${c}"
    }
}

# cpuarch
[System.String[]]$arches = 'x86','x64','arm86','arm64'
foreach ($arch in $arches)
{
    $Body = @{
        id = 0
        arch = "${arch}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/CpuArches' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${arch}"
    }
}

# detection method
[System.String[]]$list = 'Registry','FileVersion','File','Script'
foreach ($i in $list)
{
    $Body = @{
        id = 0
        method = "${i}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/DetectionProcesses' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${i}"
    }
}

# executables
[System.String[]]$list = 'msi','msix','exe','bat','ps1','cmd' #,'zip
foreach ($i in $list)
{
    $Body = @{
        id = 0
        method = "${i}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/Executables' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${i}"
    }
}

# languages
[System.String[]]$list = 'MUI','en-US'
foreach ($i in $list)
{
    $Body = @{
        id = 0
        lcid = "${i}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/Languages' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${i}"
    }
}

# transfermethod
[System.String[]]$list = 'mc','ftp','stfp','ftpes','http','https','s3'
foreach ($i in $list)
{
    $Body = @{
        id = 0
        method = "${i}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/TransferMethods' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${i}"
    }
}

# uninstallprocesses
[System.String[]]$list = 'msi','exe','exe2','inno','script'
foreach ($i in $list)
{
    $Body = @{
        id = 0
        method = "${i}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/UninstallProcesses' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
    }
    catch {
        "${i}"
    }
}

# applicationcategory
[System.String[]]$list = @('Microsoft','Utility','Developer Tools','Games','Photo & Design','Entertainment','Security','Education','Internet','Lifestyle')
foreach ($i in $list)
{
    $Body = {
        id = 0
        category = "${i}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:8080/api/ApplicationCategory' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop
        $BOdy
        Starrt-Sleep -Seconds 1
    }
    catch {
        "${i}"
    }
}
